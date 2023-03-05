﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using PRS;
using Varible;
using IDLinks;
using SendingMessages;
using KeyBoards;
using Timer = Timers.Timer;
using IDrecords;

namespace Telegram_Bot
{
    class Program : Variables
    {
        static void Main(string[] args)
        {
            DictionaryLinksNews.IDIselection();           
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
                    KeyBoard.ReplyKeyBoardMarkup();
                    SendingMessage.Greetings(replyKeyboardMarkup);
                    SendingMessage.InformationOutput();
                    ID = Convert.ToInt32(Messages.Chat.Id);
                    IdList.Add(ID);
                    IDrecord.RecordingID();
                    Console.WriteLine(IdList[IDindex]);                
                    break;
                case "Subscribe to the news.":
                    ID = Convert.ToInt32(Messages.Chat.Id);
                    IdList.Add(ID);
                    IDrecord.RecordingID();
                    Console.WriteLine(IdList[IDindex]);
                    KeyBoard.ReplyKeyBoardMarkupforInclude();
                    SendingMessage.SubscribeNews(replyKeyboardMarkupforInclude);
                    Timer.SetTimer();
                    break;
                case "No thanks.":
                    SendingMessage.Farewell();
                    SendingMessage.InformationOutput();
                    Console.WriteLine();
                    break;
                case "Get random news.":
                    HTMLparsing.HTMLpars();
                    SendingMessage.RandomNews();
                    break;
                case "Stop working.":
                    SendingMessage.StoppingWork();
                    SendingMessage.InformationOutput();
                    Console.WriteLine();
                    timer.Stop();
                    IdList.Remove(ID);
                    break;
               }
               IDrecord.RET();
            }
        }
        async static Task Error(ITelegramBotClient BotClient, Exception exception, CancellationToken Token) { }
    }
}