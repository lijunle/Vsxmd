//-----------------------------------------------------------------------
// <copyright file="Extensions.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;

    /// <summary>
    /// Extensions helper.
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Concatenates the <paramref name="value"/>s with the <paramref name="separator"/>.
        /// </summary>
        /// <param name="value">The string values.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>The concatenated string.</returns>
        internal static string Join(this IEnumerable<string> value, string separator) =>
            string.Join(separator, value);

        /// <summary>
        /// Escape the content to keep it raw in Markdown syntax.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>The escaped content.</returns>
        internal static string Escape(this string content) =>
            content.Replace("`", @"\`");

        /// <summary>
        /// Wrap the <paramref name="code"/> into Markdown backtick safely.
        /// <para>The backtick characters inside the <paramref name="code"/> reverse as it is.</para>
        /// </summary>
        /// <param name="code">The code span.</param>
        /// <returns>The Markdwon code span.</returns>
        /// <remarks>Reference: http://meta.stackexchange.com/questions/55437/how-can-the-backtick-character-be-included-in-code </remarks>
        internal static string AsCode(this string code)
        {
            string backticks = "`";
            while (code.Contains(backticks))
            {
                backticks += "`";
            }

            return code.StartsWith("`") || code.EndsWith("`")
                ? $"{backticks} {code} {backticks}"
                : $"{backticks}{code}{backticks}";
        }

        /// <summary>
        /// Split the member unit <paramref name="name"/> to segments.
        /// </summary>
        /// <param name="name">The member unit name.</param>
        /// <returns>The name segments.</returns>
        /// <example>Split <c>M:Vsxmd.Converter.#ctor(System.String)</c> to <c>["Vsxmd", "Converter", "#ctor"]</c> string list.</example>
        internal static IEnumerable<string> ToNameSegments(this string name) =>
            name.Split('(').First().Split(':').Last().Split('.');

        /// <summary>
        /// Gets the method parameter type names from the member unit <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The member unit name.</param>
        /// <returns>The method parameter type name list.</returns>
        internal static IEnumerable<string> GetParamTypes(this string name)
        {
            var paramString = name.Split('(').Last().Trim(')');

            var delta = 0;
            var list = new List<StringBuilder>()
            {
                new StringBuilder()
            };

            foreach (var character in paramString)
            {
                if (character == '{')
                {
                    delta++;
                }
                else if (character == '}')
                {
                    delta--;
                }
                else if (character == ',' && delta == 0)
                {
                    list.Add(new StringBuilder());
                }

                if (character != ',' || delta != 0)
                {
                    list.Last().Append(character);
                }
            }

            return list.Select(x => x.ToString());
        }

        /// <summary>
        /// Gets the n-th last element from the <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The source enumerable.</param>
        /// <param name="index">The index for the n-th last.</param>
        /// <returns>The target element, default(<typeparamref name="TSource"/>) if not found.</returns>
        internal static TSource NthLastOrDefault<TSource>(
            this IEnumerable<TSource> source, int index) =>
            source.Reverse().ElementAtOrDefault(index);

        /// <summary>
        /// Take all element except the last <paramref name="count"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The source enumerable.</param>
        /// <param name="count">The number to except.</param>
        /// <returns>The generated enumerable.</returns>
        internal static IEnumerable<TSource> TakeAllButLast<TSource>(
            this IEnumerable<TSource> source,
            int count) =>
            source.Reverse().Skip(count).Reverse();

        /// <summary>
        /// Convert the inline XML nodes to Markdown text.
        /// For example, it works for <c>summary</c> and <c>returns</c> elements.
        /// </summary>
        /// <param name="element">The XML element.</param>
        /// <returns>The generated Markdwon content.</returns>
        /// <example>
        /// This method converts the following <c>summary</c> element
        /// <code>
        /// <summary>The <paramref name="element" /> value is <value>null</value>, it throws <c>ArgumentException</c>. For more, see <see cref="ToMarkdownText(XElement)"/>.</summary>
        /// </code>
        /// To the below Markdown content.
        /// <code>
        /// The `element` value is `null`, it throws `ArgumentException`. For more, see `ToMarkdownText`.
        /// </code>
        /// </example>
        internal static string ToMarkdownText(this XElement element) =>
            element.Nodes()
                .Select(ToMarkdownSpan)
                .Aggregate((x, y) =>
                    x.EndsWith("\n\n")
                        ? $"{x}{y.TrimStart()}"
                        : y.StartsWith("\n\n")
                        ? $"{x.TrimEnd()}{y}"
                        : $"{x}{y}")
                .Trim();

        private static string ToMarkdownSpan(XNode node)
        {
            var text = node as XText;
            if (text != null)
            {
                return Regex.Replace(text.Value, @"\s+", " ", RegexOptions.Multiline).Escape();
            }

            var child = node as XElement;
            if (child != null)
            {
                switch (child.Name.ToString())
                {
                    case "see":
                        return $"{child.Attribute("cref").Value.ToNameSegments().Last().AsCode()}";
                    case "paramref":
                    case "typeparamref":
                        return $"{child.Attribute("name").Value.AsCode()}";
                    case "c":
                    case "value":
                        return $"{child.Value.AsCode()}";
                    case "code":
                        return $"\n\n```\n{string.Concat(child.Nodes()).Trim()}\n```\n\n";
                    case "para":
                        return $"\n\n{child.ToMarkdownText()}\n\n";
                    default:
                        return string.Empty;
                }
            }

            return string.Empty;
        }
    }
}
