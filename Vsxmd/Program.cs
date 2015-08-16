//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Program entry.
    /// </summary>
    internal class Program
    {
        private Dictionary<string, string> context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Program"/> class.
        /// </summary>
        internal Program()
        {
            this.context = new Dictionary<string, string>();
            this.context["lastNode"] = null;
        }

        /// <summary>
        /// Program main function entry.
        /// </summary>
        /// <param name="args">Program arguments.</param>
        internal static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.Error.WriteLine($"Usage: {AppDomain.CurrentDomain.FriendlyName} <input-XML-path> [output-Markdown-path]");
                Environment.Exit(1);
            }

            string xmlPath = args[0];
            string markdownPath = args.ElementAtOrDefault(1);

            if (markdownPath == null)
            {
                // replace the `xml` extension with `md` extension
                markdownPath = Regex.Replace(xmlPath, @"\.xml$", ".md", RegexOptions.IgnoreCase);
            }

            var converter = new Converter(xmlPath);
            var markdown = converter.ToMarkdown();

            File.WriteAllText(markdownPath, markdown);
        }

        private string ToMarkdown(string filePath)
        {
            var xdoc = XDocument.Load(filePath);
            var sw = new StringWriter();
            this.ToMarkdown(sw, xdoc.Root);
            return sw.ToString();
        }

        private void ToMarkdown(StringWriter sw, XElement root)
        {
            if (root.Name != "param" && this.context["lastNode"] == "param")
            {
                sw.WriteLine();
            }

            if (root.Name == "doc")
            {
                foreach (var node in root.Nodes())
                {
                    var elem = (XElement)node;
                    if (elem.Name == "assembly")
                    {
                        this.context["assembly"] = elem.Element("name").Value;
                        sw.WriteLine("\n# {0}\n", this.context["assembly"]);
                    }
                    else if (elem.Name == "members")
                    {
                        this.ToMarkdown(sw, elem);
                    }
                }
            }
            else if (root.Name == "members")
            {
                // Sorts by member name to regroup them all properly.
                var members = new List<XElement>(root.Elements("member"));
                members.Sort((a, b) =>
                    a.Attribute(XName.Get("name")).Value.Substring(2).CompareTo(
                    b.Attribute(XName.Get("name")).Value.Substring(2)));

                foreach (var member in members)
                {
                    this.ToMarkdown(sw, member);
                }
            }
            else if (root.Name == "member")
            {
                var memberName = root.Attribute(XName.Get("name")).Value;
                char memberType = memberName[0];

                if (memberType == 'M')
                {
                    memberName = this.RearrangeParametersInContext(root);
                }

                if (memberType == 'T')
                {
                    string remove = string.Format("T:{0}.", this.context["assembly"]);
                    string shortMemberName = memberName.Replace(remove, string.Empty);
                    sw.WriteLine("\n## {0}\n", shortMemberName);
                    this.context["typeName"] = shortMemberName;
                }
                else
                {
                    string shortMemberName = memberName
                        .Replace("P:" + this.context["assembly"], string.Empty)
                        .Replace(this.context["typeName"] + ".", string.Empty);

                    if (shortMemberName.StartsWith("#ctor"))
                    {
                        shortMemberName = shortMemberName.Replace("#ctor", "Constructor");
                    }

                    sw.WriteLine("\n### {0}\n", shortMemberName);
                }

                foreach (var node in root.Nodes())
                {
                    if (node.NodeType == XmlNodeType.Element)
                    {
                        this.ToMarkdown(sw, (XElement)node);
                    }
                }
            }
            else if (root.Name == "summary")
            {
                string summary = Regex.Replace(root.Value, "\\s+", " ", RegexOptions.Multiline);
                sw.WriteLine("{0}\n", summary.Trim());
            }
            else if (root.Name == "param")
            {
                if (this.context["lastNode"] != "param")
                {
                    sw.WriteLine("| Name | Description |");
                    sw.WriteLine("| ---- | ----------- |");
                }

                string paramName = root.Attribute(XName.Get("name")).Value;
                if (this.context.ContainsKey(paramName))
                {
                    sw.WriteLine("| {0} | *{1}*<br>{2} |",
                        paramName,
                        this.context[paramName],
                        Regex.Replace(root.Value, "\\s+", " ", RegexOptions.Multiline));
                }
                else
                {
                    sw.WriteLine("| {0} | *Unknown type*<br>{1} |",
                        paramName,
                        Regex.Replace(root.Value, "\\s+", " ", RegexOptions.Multiline));
                }
            }
            else if (root.Name == "returns")
            {
                sw.WriteLine("\n#### Returns\n");
                sw.WriteLine("{0}\n", Regex.Replace(root.Value, "\\s+", " ", RegexOptions.Multiline));
            }
            else if (root.Name == "remarks")
            {
                sw.WriteLine("\n#### Remarks\n");
                sw.WriteLine("{0}\n", Regex.Replace(root.Value, "\\s+", " ", RegexOptions.Multiline));
            }
            else if (root.Name == "exception")
            {
                string exName = root.Attribute("cref").Value.Substring(2);
                exName = exName.Replace(this.context["assembly"] + ".", string.Empty);
                exName = exName.Replace(this.context["typeName"] + ".", string.Empty);
                sw.WriteLine("*{0}:* {1}\n",
                    exName,
                    Regex.Replace(root.Value, "\\s+", " ", RegexOptions.Multiline));
            }

            this.context["lastNode"] = root.Name.ToString();
        }

        private string RearrangeParametersInContext(XElement methodMember)
        {
            string methodPrototype = methodMember.Attribute(XName.Get("name")).Value;
            Match match = Regex.Match(methodPrototype, "\\((.*)\\)");
            string parameterString = match.Groups[1].Value.Replace(" ", string.Empty);
            string[] parameterTypes = parameterString.Split(',');

            if (parameterTypes.Length == 0)
            {
                // nothing to do...
                return methodPrototype;
            }

            List<XElement> paramElems = new List<XElement>(methodMember.Elements("param"));
            if (parameterTypes.Length != paramElems.Count)
            {
                // the parameter count do not match, we can't do the rearrangement.
                return methodPrototype;
            }

            string newParamString = string.Empty;
            for (int i = 0; i < paramElems.Count; i++)
            {
                XElement paramElem = paramElems[i];
                string paramName = paramElem.Attribute(XName.Get("name")).Value;
                string paramType = parameterTypes[i];
                if (newParamString != string.Empty)
                {
                    newParamString += ", ";
                }

                newParamString += paramName;
                this.context[paramName] = paramType;
            }

            string newMethodPrototype = Regex.Replace(methodPrototype,
                "\\(.*\\)",
                "(" + newParamString + ")");

            return newMethodPrototype;
        }
    }
}
