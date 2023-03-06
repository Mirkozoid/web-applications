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
using Timer = Timers.Timer;
using IDrecords;

namespace Telegram_Bot
{
    class Program : Variables
    {
        public static ITelegramBotClient Bot;
        static void Main(string[] args)
        {
            DictionaryLinksNews.IDIselection();           
            BotClient.StartReceiving(Update, Error);
            Console.ReadLine();
        }
        async static Task Update(ITelegramBotClient BotClient, Update update, CancellationToken Token)
        {
            Timer.SetTimer();
            Messages = update.Message;
            if (Messages != null)
            {
               switch (Messages.Text)
               {
                case "/start":
                    KeyBoard.ReplyKeyBoardMarkup();
                    SendingMessage.Greetings(replyKeyboardMarkup);
                    SendingMessage.InformationOutput();             
                        break;
                case "Подписаться на новости.":
                    ID = Convert.ToInt32(Messages.Chat.Id);
                    IdList.Add(ID);
                    IDrecord.RecordingID();
                    SendingMessage.InformationOutput();
                    KeyBoard.ReplyKeyBoardMarkupforInclude();
                    SendingMessage.SubscribeNews(replyKeyboardMarkupforInclude);
                        break;
                case "Нет, спасибо.":
                    SendingMessage.Farewell();
                    SendingMessage.InformationOutput();
                    Console.WriteLine();
                        break;
                case "Получить новость.":
                    HTMLparsing.HTMLpars();
                    SendingMessage.RandomNews();
                        break;
                case "Остановить бота.":
                    SendingMessage.StoppingWork();
                    SendingMessage.InformationOutput();
                    Console.WriteLine();
                    timer.Stop();
                    IdList.Remove(ID);
                        break;
               }
            }
        }
        async static Task Error(ITelegramBotClient BotClient, Exception exception, CancellationToken Token) { }
    }
}