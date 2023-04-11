using HtmlAgilityPack;
using System.Collections.Generic;

namespace Telegram_Bot
{
    class CreatLinks
    {
        public static List<string> LinkList = new List<string>();
        public static HtmlWeb Ws = new HtmlWeb();
        public static HtmlDocument Document = Ws.Load(News.Url);
        public static void SortLinks()
        {
            foreach (HtmlNode node in Document.DocumentNode.SelectNodes(News.MainLink))
            {
                LinkList.Add(News.Url + node.GetAttributeValue("href", null));
                System.Console.WriteLine(LinkList[0]);
            }
        }
    }
}
