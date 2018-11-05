﻿using System;
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
            if (child.Type != TagType.head
                && child.Type != TagType.body
                && child.Type != TagType.title
                && child.Type != TagType.html)
            {
                Children.Add(child);
                child.Father = this;
            }
            else
            {
                throw new Exception("Invalid tag ");
            }
        }
    }
}
