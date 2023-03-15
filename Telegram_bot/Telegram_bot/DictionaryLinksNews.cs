using HtmlAgilityPack;
using NewsContainer;
using Parsing;
using System.Collections.Generic;

namespace IDLinks
{
    class DictionaryLinksNews
    {
        public static List<string> LinkList = new List<string>();
        public static void IDIselection()
        {
            int NumberOfNews = 0;
            foreach (HtmlNode node in ParsingHTML.Document.DocumentNode.SelectNodes(News.MainLink))
            {
                NumberOfNews++;
                LinkList.Add(News.Url + node.GetAttributeValue("href", null));
                if (NumberOfNews == 50) break;
            }
            for (int i = 0; i < LinkList.Count; i++)
            {
                System.Console.WriteLine(LinkList[i]);
                if (LinkList[i].Contains("comments")) LinkList.RemoveAt(i);
            }
        }

    }
}
