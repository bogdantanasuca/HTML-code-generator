using System;
using System.Collections.Generic;

namespace FirstApp
{
    public class TitleTag : Tag
    {
        public TitleTag() : base(TagType.title)
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
                && childTagType != TagType.html
                && childTagType != TagType.title)
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
