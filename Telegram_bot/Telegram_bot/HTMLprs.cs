using HtmlAgilityPack;
using System;
using System.Collections;
using System.Text;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PRS
{
    class HTMLparsing
    {
        public async static void HTMLpars(ITelegramBotClient botClient, Message message, CancellationToken token)
        {
            HtmlWeb ws = new HtmlWeb();
            ws.OverrideEncoding = Encoding.UTF8;
            var url = "https://www.e1.ru/";
            var mainLink = "//div[contains(@class,'GAACw')]//a[@href]";
            var headings = "//div[contains(@class,'jsL2X')]//span";
            var news = "//div[contains(@class,'qQq9J')]//p";
            HtmlDocument document = ws.Load(url);
            ArrayList linkList = new ArrayList();
            string bodyHeadingsNews = "";
            string bodyNews = "";
            int NumberOfNews = 0;
            foreach (HtmlNode node in document.DocumentNode.SelectNodes(mainLink))
            {
                NumberOfNews++;
                linkList.Add(url + node.GetAttributeValue("href", null));
                if (NumberOfNews == 10) break;
            }
            foreach (string text in linkList)
            {
                if (text.Contains("https://www.e1.ru/https://www.e1.ru/text/longread/")) continue;
                string linkText = text;
                Thread.Sleep(500);
                document = ws.Load(text);
                //Headings
                foreach (HtmlNode link in document.DocumentNode.SelectNodes(headings))
                {
                    bodyHeadingsNews = link.InnerText;                    
                }
                //News
                foreach (HtmlNode link in document.DocumentNode.SelectNodes(news))
                {
                    bodyNews = link.InnerText;
                    break;
                }              
                Console.WriteLine();
                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: bodyHeadingsNews + "\n\n" + bodyNews +
                "\nЧитать продолжение:" + "\n" + text,
                cancellationToken: token);
               
            }
        }
    }
}

