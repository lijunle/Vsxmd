using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace Vsxmd
{
    class Program
    {
        static void Main(string[] args)
        {
            Program app = new Program();
            string md = app.ToMarkdown(args[0]);
            Console.WriteLine(md);
        }



        private Dictionary<string, string> context;


        public Program()
        {
            context = new Dictionary<string, string>();
            context["lastNode"] = null;
        }

        public string ToMarkdown(string filePath)
        {
            var xdoc = XDocument.Load(filePath);
            var sw = new StringWriter();
            this.ToMarkdown(sw, xdoc.Root);
            return sw.ToString();
        }



        private void ToMarkdown(StringWriter sw, XElement root)
        {
            if (root.Name != "param" && context["lastNode"] == "param")
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
                        context["assembly"] = elem.Element("name").Value;
                        sw.WriteLine("\n# {0}\n", context["assembly"]);
                    }
                    else if (elem.Name == "members")
                    {
                        ToMarkdown(sw, elem);
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
                    ToMarkdown(sw, member);
                }
            }
            else if (root.Name == "member")
            {
                var memberName = root.Attribute(XName.Get("name")).Value;
                char memberType = memberName[0];

                if (memberType == 'M')
                {
                    memberName = RearrangeParametersInContext(root);
                }

                if (memberType == 'T')
                {
                    string remove = String.Format("T:{0}.", context["assembly"]);
                    string shortMemberName = memberName.Replace(remove, "");
                    sw.WriteLine("\n## {0}\n", shortMemberName);
                    context["typeName"] = shortMemberName;
                }
                else
                {
                    string shortMemberName = memberName.Replace("P:" + context["assembly"], "").Replace(context["typeName"] + ".", "");
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
                        ToMarkdown(sw, (XElement)node);
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
                if (context["lastNode"] != "param")
                {
                    sw.WriteLine("| Name | Description |");
                    sw.WriteLine("| ---- | ----------- |");
                }

                string paramName = root.Attribute(XName.Get("name")).Value;
                if (context.ContainsKey(paramName))
                {
                    sw.WriteLine("| {0} | *{1}*<br>{2} |",
                        paramName,
                        context[paramName],
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
                exName = exName.Replace(context["assembly"] + ".", "");
                exName = exName.Replace(context["typeName"] + ".", "");
                sw.WriteLine("*{0}:* {1}\n",
                    exName,
                    Regex.Replace(root.Value, "\\s+", " ", RegexOptions.Multiline));
            }

            context["lastNode"] = root.Name.ToString();
        }



        private string RearrangeParametersInContext(XElement methodMember)
        {
            string methodPrototype = methodMember.Attribute(XName.Get("name")).Value;
            Match match = Regex.Match(methodPrototype, "\\((.*)\\)");
            string parameterString = match.Groups[1].Value.Replace(" ", "");
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

            string newParamString = "";
            for (int i = 0; i < paramElems.Count; i++)
            {
                XElement paramElem = paramElems[i];
                string paramName = paramElem.Attribute(XName.Get("name")).Value;
                string paramType = parameterTypes[i];
                if (newParamString != "")
                {
                    newParamString += ", ";
                }
                newParamString += paramName;
                context[paramName] = paramType;
            }

            string newMethodPrototype = Regex.Replace(methodPrototype,
                "\\(.*\\)",
                "(" + newParamString + ")");

            return newMethodPrototype;
        }

    }

}
