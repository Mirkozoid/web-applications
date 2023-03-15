using HtmlAgilityPack;
using IDLinks;
using NewsContainer;
using System;
using System.Text;

namespace Parsing
{
    class ParsingHTML
    {
        public static HtmlWeb Ws = new HtmlWeb();
        public static HtmlDocument Document = Ws.Load(News.Url);
        public static string BodyHeadings;
        public static string BodyNews;
        public static string Links;
        public static void ParsingNews()
        {
            Ws.OverrideEncoding = Encoding.UTF8;
            foreach (string text in DictionaryLinksNews.LinkList)
            {
                int count = -1;
                Links = text;
                Document = Ws.Load(text);
                count++;
                if (DictionaryLinksNews.LinkList[0] == DictionaryLinksNews.LinkList[1])
                {
                    DictionaryLinksNews.LinkList.RemoveAt(0);
                }
                Console.WriteLine(text);
                //Headings
                foreach (HtmlNode link in Document.DocumentNode.SelectNodes(News.Headings))
                {
                    BodyHeadings = link.InnerText;
                    BodyHeadings = BodyHeadings.Replace("&mdash;", "-");
                    BodyHeadings = BodyHeadings.Replace("&laquo;", "");
                    BodyHeadings = BodyHeadings.Replace("&raquo;", "");
                }
                //News
                foreach (HtmlNode link in Document.DocumentNode.SelectNodes(News.Tidings))
                {
                    BodyNews = link.InnerText;
                    BodyNews = BodyNews.Replace("&mdash;", "-");
                    BodyNews = BodyNews.Replace("&laquo;", "");
                    BodyNews = BodyNews.Replace("&raquo;", "");
                    break;
                }
                Console.WriteLine();
                News.TextNews.Add($"{ParsingHTML.BodyHeadings}\n\n{ParsingHTML.BodyNews}\nЧитать далее:\n{ParsingHTML.Links}");
                //DictionaryLinksNews.LinkList.RemoveAt(0);
                if(DictionaryLinksNews.LinkList.Count == 1) DictionaryLinksNews.IDIselection();
                return;
            }
        }
    }
}

