using System;
using System.Collections.Generic;

namespace FirstApp
{
   
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.File.WriteAllText("index.html", "");
            Tag html = new Tag(TagType.Html);
            Tag body = new Tag(TagType.Body);
            Tag head = new Tag(TagType.Head);
            Tag title = new Tag(TagType.Title);
            Tag div = new Tag(TagType.Div);
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
