using System;
using System.Collections.Generic;

namespace FirstApp
{
    public class HeadTag : Tag
    {
        public HeadTag() : base(TagType.head)
        {
            IsSelfClosing = false;
            Children = new List<Element>();
            Attributes = new Dictionary<string, string>();
        }
        public override void AddElement(Element temp)
        {
        }
        public override void AddTag(Tag child)
        {
            var childTagType = child.GetTagType();

            if (childTagType != TagType.head
                && childTagType != TagType.body
                && childTagType != TagType.html)
            {
                Children.Add(child);
                child.SetFather(this);
            }
            else
            {
                throw new Exception("Invalid tag ");
            }
        }
    }
}
