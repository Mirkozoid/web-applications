using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

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
            switch (message.Text)
            {
                case "/start":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Hello, I am your financial controller, " +
                    "every day at 12 o'clock in the afternoon I will send you a little advice on how to dispose of free money." +
                    " You can also get random advice at any time or offer your own option.", cancellationToken: token) ;
                    ReplyKeyboardMarkup replyKeyboardMarkup = 
                        new(new[]
                        {
                           new KeyboardButton[] { "Include tips.", "No thanks." },
                        })
                        {
                        ResizeKeyboard = true
                        };
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Would you like to continue ?",
                    replyMarkup: replyKeyboardMarkup,cancellationToken: token);
                    Console.WriteLine($" First Name: {message.Chat.FirstName}.\n Chat Id: {message.Chat.Id}.\n Message: {message.Text}.\n at {DateTime.Now}.");
                    Console.WriteLine();                
                    break;
                case "Include tips.":
                    ReplyKeyboardMarkup replyKeyboardMarkupforInclude =
                        new(new[]
                        {
                           new KeyboardButton[] { "Get advice.", "Give your advice.","Stop working." },
                        })
                        {
                            ResizeKeyboard = true
                        };
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "What do you want ?", replyMarkup: replyKeyboardMarkupforInclude,
                    cancellationToken: token);
                    break;
                case "No thanks.":
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "We will be waiting for you, " +
                    "click /start if you want to start again.", replyMarkup: new ReplyKeyboardRemove(),
                    cancellationToken: token);                    
                    Console.WriteLine($" First Name: {message.Chat.FirstName}.\n Chat Id: {message.Chat.Id}.\n Message: {message.Text}.\n at {DateTime.Now}.");
                    Console.WriteLine();
                    break;
                case "Get advice.":

                    break;
                case "Give your advice.":

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
        async static Task Error(ITelegramBotClient botClient, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}