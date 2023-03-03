using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using PRS;
using Varible;
using IDLinks;

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
                    ReplyKeyboardMarkup replyKeyboardMarkup = 
                        new(new[]
                        {
                           new KeyboardButton[] { "Subscribe to the news.", "No thanks." },
                        })
                        {
                         ResizeKeyboard = true
                        };
                    await botClient.SendTextMessageAsync(message.Chat.Id, GreetingsText, replyMarkup: 
                    replyKeyboardMarkup, cancellationToken: token);
                    InformationOutput(message);
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
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: SubscribeNewsText, 
                    replyMarkup: replyKeyboardMarkupforInclude,cancellationToken: token);
                    break;
                case "No thanks.":
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: FarewellText, 
                    replyMarkup: new ReplyKeyboardRemove(),
                    cancellationToken: token);
                    InformationOutput(message);
                    Console.WriteLine();
                    break;
                case "Get random news.":
                    HTMLparsing.HTMLpars();
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: BodyHeadingsNews + 
                    "\n\n" + BodyNews +"\nЧитать продолжение:" + "\n" + Links, cancellationToken: token);
                        break;
                case "Stop working.":
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: StoppingWork,
                    replyMarkup: new ReplyKeyboardRemove(),
                    cancellationToken: token);
                    InformationOutput(message);
                    Console.WriteLine();
                    break;
               }          
            }
        }
        async static Task Error(ITelegramBotClient botClient, Exception exception, CancellationToken token) { }
        public static void InformationOutput(Message message)
        {
            Console.WriteLine($" First Name: {message.Chat.FirstName}.\n Chat Id: {message.Chat.Id}.\n Message: " +
            $"{message.Text}.\n at {DateTime.Now}.");
        }
    }
}