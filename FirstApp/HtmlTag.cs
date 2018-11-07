using System;
using System.Collections.Generic;

namespace FirstApp
{
    public class HtmlTag : Tag
    {
        public HtmlTag() : base(TagType.html)
        {
            IsSelfClosing = false;
            Children = new List<Element>();
            Attributes = new Dictionary<string, string>();
        }
        public override void AddTag(Tag child)
        {
            var childTagType = child.GetTagType();
            if (childTagType == TagType.head
                || childTagType == TagType.body)
            {
                Children.Add(child);
                child.SetFather(this);
            }
            else
            {
                throw new Exception("Invalid tag: " + childTagType + " with: " + Type);
            }
        }
    }
}
