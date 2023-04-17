using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegrambot;

namespace TelegramBot
{
    class Program 
    {
        public static TelegramBotClient BotClient;
        static void Main(string[] args)
        {
            BotClient = new TelegramBotClient(ItemJSON.itemJSON.tokenBot);
            NewsAPI.SearchNews();
            Timer.TimerNews();
            BotClient.StartReceiving(Update, Error);
            Console.ReadLine();
        }
        async static Task Update(ITelegramBotClient BotClient, Update update, CancellationToken Token)
        {
            var Messages = update.Message;
            if (Messages != null)
            {
               switch (Messages.Text)
               {
                case "/start":
                    Storage.users.Add(new User() { id = Messages.Chat.Id });
                    SendMessage.Greetings(Messages.Chat.Id);
                    SendMessage.InformationOutput(Messages.Chat.Id, Messages.Chat.FirstName, Messages.Text);             
                        break;
                case "Подписаться на новости.":
                    SendMessage.InformationOutput(Messages.Chat.Id, Messages.Chat.FirstName, Messages.Text);
                    SendMessage.SubscribeNews(Messages.Chat.Id);
                        break;
                case "Нет, спасибо.":
                    SendMessage.StopWork(Messages.Chat.Id);
                    SendMessage.InformationOutput(Messages.Chat.Id, Messages.Chat.FirstName, Messages.Text);
                    Console.WriteLine();
                        break;
                case "Получить новость.":
                    SendMessage.RandomNews(Messages.Chat.Id);
                        break;
                case "Остановить бота.":
                    Storage.users.Remove(Storage.users.Find(User => User.id == Messages.Chat.Id));
                    SendMessage.StopWork(Messages.Chat.Id);
                    SendMessage.InformationOutput(Messages.Chat.Id, Messages.Chat.FirstName, Messages.Text);
                    Console.WriteLine();
                        break;
               }
            }
        }
        async static Task Error(ITelegramBotClient BotClient, Exception exception, CancellationToken Token) { }
    }
}