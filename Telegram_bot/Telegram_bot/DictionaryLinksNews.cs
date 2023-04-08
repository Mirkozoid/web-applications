using HtmlAgilityPack;
using System.Collections.Generic;

namespace Telegram_Bot
{
    class DictionaryLinksNews
    {
        public static List<string> LinkList = new List<string>();
        public static void IdLinks()
        {
            int count = 0;
            foreach (HtmlNode node in HtmlPars.Document.DocumentNode.SelectNodes(News.MainLink))
            {
                count++;
                if (node.GetAttributeValue("href", null).Contains("comments") || 
                node.GetAttributeValue("href", null).Contains("/news/commodities-news/article-2247401")) continue;
                //System.Console.WriteLine(node.GetAttributeValue("href", null));
                LinkList.Add(News.Url + node.GetAttributeValue("href", null));
                if (count == 50) break;
            }
            for (int i = 0; i < LinkList.Count; i++)
            {
                System.Console.WriteLine(LinkList[i]);
            }
        }
    }
}
