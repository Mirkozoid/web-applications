using HtmlAgilityPack;
using System;
using System.Collections;
using System.Text;
using System.Threading;

namespace PRS
{
    class HTMLprs
    {
        public Action doAfter { get { return DoAfter; } set { DoAfter = value; } }
        private Action DoAfter;

        public void doSomething()
        {
            doafter();
        }

        private void doafter()
        {
            DoAfter();
        }
        public static void HTMLpars()
        {
            HtmlWeb ws = new HtmlWeb();
            ws.OverrideEncoding = Encoding.UTF8;
            var url = "https://www.e1.ru/";
            var mainLink = "//div[contains(@class,'GAACw')]//a[@href]";
            var headings = "//div[contains(@class,'jsL2X')]//span";
            var news = "//div[contains(@class,'qQq9J')]//p";
            var time = "//div[contains(@class,'zhFxW')]//a";
            HtmlDocument document = ws.Load(url);
            ArrayList linkList = new ArrayList();
            string bodyHeadingsNews = "";
            string bodyNews = "";
            string bodyTimeNews = "";
            int NumberOfNews = 0;
            foreach (HtmlNode node in document.DocumentNode.SelectNodes(mainLink))
            {
                NumberOfNews++;
                Console.WriteLine("https://www.e1.ru/" + node.GetAttributeValue("href", null));
                linkList.Add(url + node.GetAttributeValue("href", null));
                if (NumberOfNews == 100) break;
            }
            foreach (string text in linkList)
            {
                if (text.Contains("https://www.e1.ru/https://www.e1.ru/text/longread/")) continue;
                Thread.Sleep(500);
                Console.WriteLine(text);
                document = ws.Load(text);
                //Headings
                foreach (HtmlNode link in document.DocumentNode.SelectNodes(headings))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    bodyHeadingsNews = link.InnerText;
                    Console.WriteLine(link.InnerText);
                }
                //News
                foreach (HtmlNode link in document.DocumentNode.SelectNodes(news))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    bodyNews = link.InnerText;
                    Console.WriteLine("\n" + link.InnerText);
                    break;
                }
                //Time
                foreach (HtmlNode link in document.DocumentNode.SelectNodes(time))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    bodyTimeNews = link.InnerText;
                    Console.WriteLine(link.InnerText);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(bodyHeadingsNews + "\n\n" + bodyNews + "\n\n" + bodyTimeNews);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
        }
    }
}

