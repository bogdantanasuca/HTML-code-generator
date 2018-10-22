using System.Collections.Generic;

namespace FirstApp
{
    public class BaseClass
    {
        public TagType Type { get; set; }
        public IDictionary<string, string> Attributes = new Dictionary<string, string>();
        public string Content;
        //List<Tag> Children = new List<Tag>();
    }

}
