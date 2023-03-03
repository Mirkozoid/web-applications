using HtmlAgilityPack;
using System;
using System.Collections;
using System.Text;
using Varible;

namespace PRS
{
    class HTMLparsing : Variables
    {
        public static void HTMLpars()
        {
            Ws.OverrideEncoding = Encoding.UTF8;
            HtmlDocument document = Ws.Load(Url);
            ArrayList linkList = new ArrayList();
            int NumberOfNews = 0;
            foreach (HtmlNode node in document.DocumentNode.SelectNodes(MainLink))
            {
                NumberOfNews++;
                Console.WriteLine(NumberOfNews);
                linkList.Add(Url + node.GetAttributeValue("href", null));
                if (NumberOfNews == 20) break;
            }
            foreach (string text in linkList)
            {
                Links = text;
                if (text.Contains("https://www.e1.ru/https://www.e1.ru/text/longread/")) continue;
                document = Ws.Load(text);
                //Headings
                foreach (HtmlNode link in document.DocumentNode.SelectNodes(Headings))
                {
                    BodyHeadingsNews = link.InnerText;
                }
                //News
                foreach (HtmlNode link in document.DocumentNode.SelectNodes(News))
                {
                    BodyNews = link.InnerText;
                    break;
                }
                Console.WriteLine();
                return;
            }
        }
    }
}

