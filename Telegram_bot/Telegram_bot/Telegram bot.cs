using System;
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
            CreatLinks.SortLinks();
            News.RenderNews();
            Timer.TimerNews();
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
                    User.users.Add(new User() { id = Messages.Chat.Id });
                    SendMessage.Greetings();
                    SendMessage.InformationOutput();             
                        break;
                case "Подписаться на новости.":
                    SendMessage.InformationOutput();
                    SendMessage.SubscribeNews();
                        break;
                case "Нет, спасибо.":
                    SendMessage.StopWork();
                    SendMessage.InformationOutput();
                    Console.WriteLine();
                        break;
                case "Получить новость.":
                    SendMessage.RandomNews();
                        Console.WriteLine(News.textNews[6], News.textNews[5]);
                        break;
                case "Остановить бота.":
                    User.users.Remove(User.users.Find(User => User.id == Messages.Chat.Id));
                    SendMessage.StopWork();
                    SendMessage.InformationOutput();
                    Console.WriteLine();
                        break;
               }
            }
        }
        async static Task Error(ITelegramBotClient BotClient, Exception exception, CancellationToken Token) { }
    }
}