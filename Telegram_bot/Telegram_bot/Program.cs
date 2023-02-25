using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
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
            if (message.Text != null || message.Text == null)
            {
              var inlineKeyboard = new InlineKeyboardMarkup(new[]
              {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Include tips"),
                    InlineKeyboardButton.WithCallbackData("No thanks")
                }
              });
                await botClient.SendTextMessageAsync(message.Chat.Id, "Hello, I am your financial controller, " +
                    "every day at 12 o'clock in the afternoon I will send you a little advice on how to dispose of free money." +
                    " You can also get random advice at any time or offer your own option.", replyMarkup: inlineKeyboard);
                Console.WriteLine($" First Name: {message.Chat.FirstName}\n Chat Id: {message.Chat.Id}\n Message: {message.Text}\n at {message.Date}.");
                
                Console.WriteLine();           
                return;
            }
            
        }
        private async static void BotOnCallBackQueryReceived(ITelegramBotClient botClient, Update inlineKeyboard)
        {
            string selectedOption = inlineKeyboard.CallbackQuery.Data;
            await botClient.AnswerCallbackQueryAsync(inlineKeyboard.CallbackQuery.Id, $"{selectedOption}");
        }
        async static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
          
        }
    }
}
