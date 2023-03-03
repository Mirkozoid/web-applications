using HtmlAgilityPack;
using Varible;

namespace IDLinks
{
    class DictionaryLinksNews : Variables
    {
        public static void IDIselection()
        {
            int NumberOfNews = 0;
            foreach (HtmlNode node in Document.DocumentNode.SelectNodes(MainLink))
            {
                NumberOfNews++;
                LinkList.Add(Url + node.GetAttributeValue("href", null));
                if (NumberOfNews == 39) break;
            }
        }

    }
}
