using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns.Builder
{
    class HtmlElementFluentCI
    {
        protected string Name, Text;
        /*Do public for With Impilict Operator*/
        protected List<HtmlElementFluentCI> innerHtmlElements = new List<HtmlElementFluentCI>();

        private const int indentSize = 2;
        
        /*Do public for With Impilict Operator*/
        protected HtmlElementFluentCI() { }

        /*Do public for With Impilict Operator*/
        protected HtmlElementFluentCI(string name, string text)
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

        // factory method for force to use HtmlBuilder
        public static HtmlBuilderFluentCI Create(string name) => new
        HtmlBuilderFluentCI(name);
    }

    class HtmlBuilderFluentCI 
    {
        protected readonly string rootName;
        protected HtmlElement root = new HtmlElement();
        public HtmlBuilderFluentCI(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }
        public HtmlBuilderFluentCI AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.innerHtmlElements.Add(e);

            //Main change for Fluent Builder
            return this;
        }
        public override string ToString() => root.ToString();

        /*Do public for With Impilict Operator*/
        //public static implicit operator HtmlElementFluentCI(HtmlBuilderFluentCI builder)
        //{
        //    return builder.root;
        //}
    }

    class DemoFluentCI
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

            var htmlElement = new HtmlElementFluent();

            //Communicating Intent provide error here
            //var htmlElementCI = new HtmlElementFluentCI();

            //Communicating Intent
            var builder = HtmlElementFluentCI.Create("ul");
            builder.AddChild("li", "hello").AddChild("li", "world");
            Console.WriteLine(builder.ToString());

            /*With Impilict Operator*/
            //HtmlElement root = HtmlElement
            // .Create("ul")
            // .AddChildFluent("li", "hello")
            // .AddChildFluent("li", "world");
            //WriteLine(root);

        }
    }
}
