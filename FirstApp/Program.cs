using System;
using System.Collections.Generic;

namespace FirstApp
{
    enum TagType
    {
        HTML=1,
        BODY=2,
        HEAD=3,
        TITLE=4,
        DIV=5,
        H1=6
    }
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.File.WriteAllText("index.html", "");
            Tag html = new Tag(TagType.HTML);
            Tag body = new Tag(TagType.BODY);
            Tag head = new Tag(TagType.HEAD);
            Tag title = new Tag(TagType.TITLE);
            Tag div = new Tag(TagType.DIV);
            Tag h1 = new Tag(TagType.H1);

            html.AddChild(head);
            html.AddChild(body);
            head.AddChild(title);
            title.SetContent("Titlu");
            body.AddChild(div);
            div.AddChild(h1);
            div.AddAttribute("color", "blue");
            h1.SetContent("Gigi 4 the WIN!!");

            html.Render();
        }
    }


}
