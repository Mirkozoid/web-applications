using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using HtmlAgilityPack;
using System.Text;
using System.Collections;
using PRS;

namespace Telegram_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            var botClient = new TelegramBotClient("6104127558:AAF00d6Blwvz4DgCVWzf8usO-xPlR1Ehz2U");
            botClient.StartReceiving(Update, Error);
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
                    HTMLparsing.HTMLpars(botClient,message,token);
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