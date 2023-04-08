﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telegram_Bot
{
    class Program 
    {
        public static TelegramBotClient BotClient;
        public static CancellationToken Token;
        public static Message Messages;
        static void Main(string[] args)
        {
            BotClient = new TelegramBotClient("6104127558:AAF00d6Blwvz4DgCVWzf8usO-xPlR1Ehz2U");
            DictionaryLinksNews.IdLinks();
            Timer.SetTimer();
            BotClient.StartReceiving(Update, Error);
            Console.ReadLine();
        }
        async static Task Update(ITelegramBotClient BotClient, Update update, CancellationToken Token)
        {
            Messages = update.Message;
            if (Messages != null)
            {
               switch (Messages.Text)
               {
                case "/start":
                    SendingMessage.Greetings();
                    SendingMessage.InformationOutput();             
                        break;
                case "Подписаться на новости.":
                    User.users.Add(new User(){id = Messages.Chat.Id});
                        News.RenderNews();
                        SendingMessage.InformationOutput();
                    SendingMessage.SubscribeNews();
                        break;
                case "Нет, спасибо.":
                    SendingMessage.StopWork();
                    SendingMessage.InformationOutput();
                    Console.WriteLine();
                        break;
                case "Получить новость.":
                    News.RenderNews();
                    SendingMessage.RandomNews();
                        break;
                case "Остановить бота.":
                        Console.WriteLine(User.users.Count);
                    User.users.Remove(User.users.Find(User => User.id == Messages.Chat.Id));
                        Console.WriteLine(User.users.Count);
                        SendingMessage.StopWork();
                    SendingMessage.InformationOutput();
                    Console.WriteLine();
                        break;
               }
            }
        }
        async static Task Error(ITelegramBotClient BotClient, Exception exception, CancellationToken Token) { }
    }
}