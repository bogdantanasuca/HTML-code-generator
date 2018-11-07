using System;
using System.Collections.Generic;

namespace FirstApp
{
    public class DivTag : Tag
    {
        public DivTag() : base(TagType.div)
        {
            IsSelfClosing = false;
            Children = new List<Element>();
            Attributes = new Dictionary<string, string>();
        }
        public override void AddTag(Tag child)
        {
            var childTagType = child.GetTagType();

            if (childTagType != TagType.head
                && childTagType != TagType.body
                && childTagType != TagType.title
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
