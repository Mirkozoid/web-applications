using HtmlAgilityPack;
using System;
using System.Text;

namespace Telegram_Bot
{
    class HtmlPars
    {
        public static string BodyNews;
        public static string Links;
        public static void ParsNews()
        {
            CreatLinks.Ws.OverrideEncoding = Encoding.UTF8;
            foreach (string text in CreatLinks.LinkList)
            {
                Links = text;
                CreatLinks.Document = CreatLinks.Ws.Load(text);
                foreach (HtmlNode link in CreatLinks.Document.DocumentNode.SelectNodes(News.Tidings))
                {
                    BodyNews = link.InnerText;
                }
                Console.WriteLine(BodyNews);
                CreatLinks.LinkList.RemoveAt(0);
                return;
            }
        }
    }
}

