using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns.Builder
{
    class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> innerHtmlElements = new List<HtmlElement>();

        private const int indentSize = 2;
        public HtmlElement() { }
        public HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;
        }
        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.Append($"{i}<{Name}>\n");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.Append(Text);
                sb.Append("\n");
            }

            foreach (var e in innerHtmlElements)
                sb.Append(e.ToStringImpl(indent + 1));

            sb.Append($"{i}</{Name}>\n");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    class HtmlBuilder
    {
        protected readonly string rootName;
        protected HtmlElement root = new HtmlElement();
        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }
        public void AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.innerHtmlElements.Add(e);
        }
        public override string ToString() => root.ToString();
    }

    class Demo
    {
        static void Main2(string[] args)
        {
            /*Bad version*/
            //var words = new[] { "hello", "world" };

            //var sb = new StringBuilder();
            
            //sb.Clear();
            //sb.Append("<ul>");
            //foreach (var word in words)
            //{
            //    sb.AppendFormat("<li>{0}</li>", word);
            //}
            //sb.Append("</ul>");
            //Console.WriteLine(sb);
            /**/

            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");
            Console.WriteLine(builder.ToString());

        }
    }
}
