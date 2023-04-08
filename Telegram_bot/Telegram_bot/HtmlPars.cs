using HtmlAgilityPack;
using System;
using System.Text;

namespace Telegram_Bot
{
    class HtmlPars
    {
        public static HtmlWeb Ws = new HtmlWeb();
        public static HtmlDocument Document = Ws.Load(News.Url);
        public static string BodyHeadings;
        public static string BodyNews;
        public static string Links;
        public static void ParsNews()
        {
            Ws.OverrideEncoding = Encoding.UTF8;
            foreach (string text in DictionaryLinksNews.LinkList)
            {
                Links = text;
                Document = Ws.Load(text);
                if (DictionaryLinksNews.LinkList[0] == DictionaryLinksNews.LinkList[1])
                {
                    DictionaryLinksNews.LinkList.RemoveAt(0);
                }
                Console.WriteLine(text);
                //Headings
                foreach (HtmlNode link in Document.DocumentNode.SelectNodes(News.Headings))
                {
                    BodyHeadings = link.InnerText;
                }
                //News
                foreach (HtmlNode link in Document.DocumentNode.SelectNodes(News.Tidings))
                {
                    BodyNews = link.InnerText;
                }
            }
        }
    }
}

