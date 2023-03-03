using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Varible;

namespace SendingMessages
{
    class SendingMessage : Variables
    {
        public async static void Greetings(ITelegramBotClient botClient, Message message, CancellationToken token,
        ReplyKeyboardMarkup replyKeyboardMarkup)
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, GreetingsText, replyMarkup:
            replyKeyboardMarkup, cancellationToken: token);
        }
        public async static void SubscribeNews(ITelegramBotClient botClient, Message message, CancellationToken token,
        ReplyKeyboardMarkup replyKeyboardMarkupforInclude)
        {
            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: SubscribeNewsText,
            replyMarkup: replyKeyboardMarkupforInclude, cancellationToken: token);
        }
        public async static void Farewell(ITelegramBotClient botClient, Message message, CancellationToken token)
        {
            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: FarewellText,
            replyMarkup: new ReplyKeyboardRemove(), cancellationToken: token);
        }
        public async static void StoppingWork(ITelegramBotClient botClient, Message message, CancellationToken token)
        {
            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: StoppingWorkText,
            replyMarkup: new ReplyKeyboardRemove(), cancellationToken: token);
        }
        public async static void RandomNews(ITelegramBotClient botClient, Message message, CancellationToken token)
        {
            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: BodyHeadingsNews +
            "\n\n" + BodyNews + "\nЧитать продолжение:" + "\n" + Links, cancellationToken: token);
        }
        public static void InformationOutput(Message message)
        {
            Console.WriteLine($" First Name: {message.Chat.FirstName}.\n Chat Id: {message.Chat.Id}.\n Message: " +
            $"{message.Text}.\n at {DateTime.Now}.");
        }
    }
}
