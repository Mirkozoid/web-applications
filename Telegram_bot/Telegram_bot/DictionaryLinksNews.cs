using HtmlAgilityPack;
using News;
using ParsingHTML;
using System.Collections.Generic;

namespace IDLinks
{
    class DictionaryLinksNews
    {
        public static List<string> LinkList = new List<string>();
        public static void IDIselection()
        {
            int NumberOfNews = 0;
            foreach (HtmlNode node in Parsing.Document.DocumentNode.SelectNodes(NewsContainer.MainLink))
            {
                NumberOfNews++;
                LinkList.Add(NewsContainer.Url + node.GetAttributeValue("href", null));
                if (NumberOfNews == 50) break;
            }
            for (int i = 0; i < LinkList.Count; i++)
            {
                if (LinkList[i].Contains("comments")) LinkList.RemoveAt(i);
            }
        }

    }
}
