﻿using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Varible;

namespace SendingMessages
{
    class SendingMessage : Variables
    {
        public async static void Greetings(ReplyKeyboardMarkup replyKeyboardMarkup)
        {
            await BotClient.SendTextMessageAsync(Messages.Chat.Id, GreetingsText, replyMarkup:
            replyKeyboardMarkup, cancellationToken: Token);
        }
        public async static void SubscribeNews(ReplyKeyboardMarkup replyKeyboardMarkupforInclude)
        {
            await BotClient.SendTextMessageAsync(chatId: Messages.Chat.Id, text: SubscribeNewsText,
            replyMarkup: replyKeyboardMarkupforInclude, cancellationToken: Token);
        }
        public async static void Farewell()
        {
            await BotClient.SendTextMessageAsync(chatId: Messages.Chat.Id, text: FarewellText,
            replyMarkup: new ReplyKeyboardRemove(), cancellationToken: Token);
        }
        public async static void StoppingWork()
        {
            await BotClient.SendTextMessageAsync(chatId: Messages.Chat.Id, text: StoppingWorkText,
            replyMarkup: new ReplyKeyboardRemove(), cancellationToken: Token);
        }
        public async static void RandomNews()
        {
            await BotClient.SendTextMessageAsync(chatId: Messages.Chat.Id, text: BodyHeadingsNews +
            "\n\n" + BodyNews + "\nЧитать продолжение:" + "\n" + Links, cancellationToken: Token);
        }
        public static void InformationOutput()
        {
            Console.WriteLine($" First Name: {Messages.Chat.FirstName}.\n Chat Id: {Messages.Chat.Id}.\n Message: " +
            $"{Messages.Text}.\n at {DateTime.Now}.");
        }
    }
}
