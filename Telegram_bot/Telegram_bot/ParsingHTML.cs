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
                int count = -1;
                Links = text;
                Document = Ws.Load(text);
                count++;
                if (LinkList[0] == LinkList[1])
                {
                    LinkList.RemoveAt(0);
                }
                Console.WriteLine(text);
                //Headings
                foreach (HtmlNode link in Document.DocumentNode.SelectNodes(Headings))
                {
                    BodyHeadingsNews = link.InnerText;
                    BodyHeadingsNews = BodyHeadingsNews.Replace("&mdash;", "-");
                    BodyHeadingsNews = BodyHeadingsNews.Replace("&laquo;", "");
                    BodyHeadingsNews = BodyHeadingsNews.Replace("&raquo;", "");
                }
                //News
                foreach (HtmlNode link in Document.DocumentNode.SelectNodes(News))
                {
                    BodyNews = link.InnerText;
                    BodyNews = BodyNews.Replace("&mdash;", "-");
                    BodyNews = BodyNews.Replace("&laquo;", "");
                    BodyNews = BodyNews.Replace("&raquo;", "");
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

