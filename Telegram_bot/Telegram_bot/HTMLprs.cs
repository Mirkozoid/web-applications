using HtmlAgilityPack;
using IDLinks;
using System;
using System.Text;
using Varible;

namespace PRS
{
    class HTMLparsing : Variables
    {
        public static void HTMLpars()
        {
            Ws.OverrideEncoding = Encoding.UTF8;
            foreach (string text in LinkList)
            {
                Links = text;
                if (text.Contains("https://www.e1.ru/https://www.e1.ru/text/longread/")) continue;
                Document = Ws.Load(text);
                //Headings
                foreach (HtmlNode link in Document.DocumentNode.SelectNodes(Headings))
                {
                    BodyHeadingsNews = link.InnerText;
                }
                //News
                foreach (HtmlNode link in Document.DocumentNode.SelectNodes(News))
                {
                    BodyNews = link.InnerText;
                    break;
                }
                Console.WriteLine();
                LinkList.RemoveAt(0);
                if(LinkList.Count == 1) DictionaryLinksNews.IDIselection();
                return;
            }
        }
    }
}

