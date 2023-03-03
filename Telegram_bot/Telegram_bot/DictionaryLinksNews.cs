using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Console.WriteLine(NumberOfNews);
                LinkList.Add(Url + node.GetAttributeValue("href", null));
                if (NumberOfNews == 50) break;
            }
        }

    }
}
