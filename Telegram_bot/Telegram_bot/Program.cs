using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using HtmlAgilityPack;
using System.Text;
using System.Collections;

namespace Telegram_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            var botClient = new TelegramBotClient("6104127558:AAF00d6Blwvz4DgCVWzf8usO-xPlR1Ehz2U");
            botClient.StartReceiving(Update, Error);
            Program HTMLprs = new Program();
            Console.ReadLine();
        }
        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message != null)
            {
               switch (message.Text)
               {
                case "/start":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Hello, I am your financial controller" +
                    "three times a day I will send you news about how things are on the market." +
                    " You can also get random news at any time.", cancellationToken: token);
                    ReplyKeyboardMarkup replyKeyboardMarkup = 
                        new(new[]
                        {
                           new KeyboardButton[] { "Subscribe to the news.", "No thanks." },
                        })
                        {
                        ResizeKeyboard = true
                        };
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Would you like to continue ?",
                    replyMarkup: replyKeyboardMarkup,cancellationToken: token);
                    Console.WriteLine($" First Name: {message.Chat.FirstName}.\n Chat Id: {message.Chat.Id}.\n Message: {message.Text}.\n at {DateTime.Now}.");
                    Console.WriteLine();                
                    break;
                case "Subscribe to the news.":
                    ReplyKeyboardMarkup replyKeyboardMarkupforInclude =
                        new(new[]
                        {
                           new KeyboardButton[] { "Get random news.","Stop working." },
                        })
                        {
                            ResizeKeyboard = true
                        };
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "You have successfully subscribed. Every day at 10:00," +
                    " 15:00 and 20:00 you will receive news from the world of exchanges, stocks and economics.\n\nWhat do you want ?",
                    replyMarkup: replyKeyboardMarkupforInclude,
                    cancellationToken: token);
                    break;
                case "No thanks.":
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "We will be waiting for you, " +
                    "click /start if you want to start again.", replyMarkup: new ReplyKeyboardRemove(),
                    cancellationToken: token);                    
                    Console.WriteLine($" First Name: {message.Chat.FirstName}.\n Chat Id: {message.Chat.Id}.\n Message: {message.Text}.\n at {DateTime.Now}.");
                    Console.WriteLine();
                    break;
                case "Get random news.":
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
                            linkList.Add(url + node.GetAttributeValue("href", null));
                            if (NumberOfNews == 1) break;
                        }
                        foreach (string text in linkList)
                        {
                            if (text.Contains("https://www.e1.ru/https://www.e1.ru/text/longread/")) continue;
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
                            //Time
                            foreach (HtmlNode link in document.DocumentNode.SelectNodes(time))
                            {                                
                                bodyTimeNews = link.InnerText;
                            }
                            Console.WriteLine();
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: bodyHeadingsNews + "\n\n" + bodyNews +
                            "\nЧитать продолжение:" + "\n" + text,
                            cancellationToken: token);
                        }
                        break;
                case "Stop working.":
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "We will be waiting for you, " +
                    "click /start if you want to start again.", replyMarkup: new ReplyKeyboardRemove(),
                    cancellationToken: token);
                    Console.WriteLine($" First Name: {message.Chat.FirstName}.\n Chat Id: {message.Chat.Id}.\n Message: {message.Text}.\n at {DateTime.Now}.");
                    Console.WriteLine();
                    break;
               }          
            }
        }
        async static Task Error(ITelegramBotClient botClient, Exception exception, CancellationToken token)
        { 
        }
    }
}