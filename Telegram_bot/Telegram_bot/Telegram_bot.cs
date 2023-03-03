using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using PRS;
using Varible;
using IDLinks;
using SendingMessages;
using KeyBoards;

namespace Telegram_Bot
{
    class Program : Variables
    {
        static void Main(string[] args)
        {
            var botClient = new TelegramBotClient("6104127558:AAF00d6Blwvz4DgCVWzf8usO-xPlR1Ehz2U");
            DictionaryLinksNews.IDIselection();
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
                    KeyBoard.ReplyKeyBoardMarkup();
                    SendingMessage.Greetings(botClient, message, token, replyKeyboardMarkup);
                    SendingMessage.InformationOutput(message);
                    Console.WriteLine();                
                    break;
                case "Subscribe to the news.":
                    KeyBoard.ReplyKeyBoardMarkupforInclude();
                    SendingMessage.SubscribeNews(botClient, message, token, replyKeyboardMarkupforInclude);
                    break;
                case "No thanks.":
                    SendingMessage.Farewell(botClient, message, token);
                    SendingMessage.InformationOutput(message);
                    Console.WriteLine();
                    break;
                case "Get random news.":
                    HTMLparsing.HTMLpars();
                    SendingMessage.RandomNews(botClient, message, token);
                    break;
                case "Stop working.":
                    SendingMessage.StoppingWork(botClient, message, token);
                    SendingMessage.InformationOutput(message);
                    Console.WriteLine();
                    break;
               }          
            }
        }
        async static Task Error(ITelegramBotClient botClient, Exception exception, CancellationToken token) { }
    }
}