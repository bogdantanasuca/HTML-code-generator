using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FirstApp
{
    class Tag : Element
    {
        public List<Element> Children { get; set; }
        public bool IsSelfClosing { get; set; }

        public TagType Type { get; set; }
        public IDictionary<string, string> Attributes = new Dictionary<string, string>();
        public Tag Father { get; set; }
        private Tag() { }
        public Tag(TagType Type)
        {
            this.Type = Type;
            this.Content = "";
            this.Father = null;
        }
        public Tag GetFather()
        {
            return Father;
        }
        virtual public void AddTag(Tag child)
        {
            Children.Add(child);
            child.Father = this;
        }

        public void AddElement(Element Temp)
        {
            Children.Add(Temp);
        }

        public void AddAttribute(string attribute, string value)
        {
            value = '"' + value + '"';
            this.Attributes.Add(attribute, value);
        }

        public void Render()
        {
            Console.WriteLine("Render of the Html file:");
            Console.WriteLine(CreateString(0));
            File.WriteAllText("index.html", CreateString(0).ToString());
        }
        public StringBuilder CreateString(int Depth)
        {
            StringBuilder text = new StringBuilder("");
            text = AddTabs(Depth, text);
            text.Append("<" + Type);
            foreach (KeyValuePair<string, string> kvp in Attributes)
            {
                text.Append(" " + kvp.Key + "=" + kvp.Value);
            }
            text.Append(">\n");
            foreach (var child in Children)
            {
                if (child is Tag)
                {
                    var temp = child as Tag;
                    text.Append(temp.CreateString(Depth + 1));
                }
                else
                {
                    text = AddTabs(Depth + 1, text);
                    text.Append(child.Content + "\n");
                }
            }
            text = AddTabs(Depth, text);
            text.Append("</" + Type + ">\n");
            return text;
        }
        private StringBuilder AddTabs(int times, StringBuilder text)
        {
            for (var index = 0; index < times; index++)
            {
                text.Append("\t");
            }
            return text;
        }
    }

}
