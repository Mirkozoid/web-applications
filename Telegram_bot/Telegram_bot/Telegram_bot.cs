using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using ParsingHTML;
using IDLinks;
using SendingMessages;
using KeyBoards;
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
                    SendingMessage.Greetings(KeyBoard.replyKeyboardMarkup);
                    SendingMessage.InformationOutput();             
                        break;
                case "Подписаться на новости.":
                    Users.ID = Convert.ToInt32(Messages.Chat.Id);
                    Users.ListId.Add(Users.ID);
                    Users.UserId();
                    SendingMessage.InformationOutput();
                    KeyBoard.ReplyKeyBoardMarkupforInclude();
                    SendingMessage.SubscribeNews(KeyBoard.replyKeyboardMarkupforInclude);
                        break;
                case "Нет, спасибо.":
                    SendingMessage.StoppingWork();
                    SendingMessage.InformationOutput();
                    Console.WriteLine();
                        break;
                case "Получить новость.":
                    Parsing.ParsingNews();
                    SendingMessage.RandomNews();
                        break;
                case "Остановить бота.":
                    SendingMessage.StoppingWork();
                    SendingMessage.InformationOutput();
                    Console.WriteLine();
                    Timer.timer.Stop();
                    Users.ListId.Remove(Users.ID);
                        break;
               }
            }
        }
        async static Task Error(ITelegramBotClient BotClient, Exception exception, CancellationToken Token) { }
    }
}