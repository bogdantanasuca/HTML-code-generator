using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp
{
    class HtmlTag : Tag
    {
        public HtmlTag() : base(TagType.html)
        {
            IsSelfClosing = false;
            Children = new List<Element>();
        }
        public override void AddTag(Tag child)
        {
            if (child.Type == TagType.head
                || child.Type == TagType.body)
            {
                Children.Add(child);
                child.Father = this;
            }
            else
            {
                throw new Exception("Invalid tag: "+ child.Type+" with: "+this.Type);
            }
        }
    }
}
