using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineKeyboardButtons;
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
            if (message.Text != null)
            {

                //var firstButton = new InlineKeyboardButton("Include tips");
                //firstButton.CallbackData = "Include tips";
                //var secondButton = new InlineKeyboardButton("No thanks");
                //secondButton.CallbackData = "No thanks";
                //var inlineKeyboard = new InlineKeyboardMarkup(new[]
                //{
                //      new[]
                //      {
                //       firstButton,
                //       secondButton
                //      }
                //});
                await botClient.SendTextMessageAsync(message.Chat.Id, "Hello, I am your financial controller, " +
                    "every day at 12 o'clock in the afternoon I will send you a little advice on how to dispose of free money." +
                    " You can also get random advice at any time or offer your own option.");
                switch (message.Text)
                {
                    case "Include tips":
                        await botClient.SendTextMessageAsync(message.Chat.Id, "1");
                        break;
                    case "No thanks":
                        await botClient.SendTextMessageAsync(message.Chat.Id, "2");
                        break;
                    default:
                        break;
                }
                Console.WriteLine($" First Name: {message.Chat.FirstName}\n Chat Id: {message.Chat.Id}\n Message: {message.Text}\n at {DateTime.Now}.");
                Console.WriteLine();

            }
        }
        async static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg)
        {

        }
    }
}