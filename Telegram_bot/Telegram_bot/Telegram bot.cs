﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Parsing;
using IDLinks;
using SendingMessages;
using Timer = Timers.Timer;
using User;

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
            DictionaryLinksNews.IDIselection();
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
                    Users.ListUserID.Add(Messages.Chat.Id);
                    SendingMessage.InformationOutput();
                    SendingMessage.SubscribeNews();
                        break;
                case "Нет, спасибо.":
                    SendingMessage.StopWork();
                    SendingMessage.InformationOutput();
                    Console.WriteLine();
                        break;
                case "Получить новость.":
                    ParsingHTML.ParsingNews();
                    SendingMessage.RandomNews();
                        break;
                case "Остановить бота.":
                    SendingMessage.StopWork();
                    SendingMessage.InformationOutput();
                    Console.WriteLine();
                    Users.ListUserID.Remove(Messages.Chat.Id);
                        break;
               }
            }
        }
        async static Task Error(ITelegramBotClient BotClient, Exception exception, CancellationToken Token) { }
    }
}