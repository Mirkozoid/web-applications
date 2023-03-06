using ParsingHTML;
using System;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram_Bot;
using Texts;
using User;

namespace SendingMessages
{
    class SendingMessage
    {
        public async static void Greetings(ReplyKeyboardMarkup replyKeyboardMarkup)
        {
            await Program.BotClient.SendTextMessageAsync(chatId: Program.Messages.Chat.Id, Text.GreetingsText, replyMarkup:
            replyKeyboardMarkup, cancellationToken: Program.Token);
        }
        public async static void SubscribeNews(ReplyKeyboardMarkup replyKeyboardMarkupforInclude)
        {
            await Program.BotClient.SendTextMessageAsync(chatId: Program.Messages.Chat.Id, text: Text.SubscribeNewsText,
            replyMarkup: replyKeyboardMarkupforInclude, cancellationToken: Program.Token);
        }
        public async static void StoppingWork()
        {
            await Program.BotClient.SendTextMessageAsync(chatId: Program.Messages.Chat.Id, text: Text.StoppingWorkText,
            replyMarkup: new ReplyKeyboardRemove(), cancellationToken: Program.Token);
        }
        public async static void RandomNews()
        {
            await Program.BotClient.SendTextMessageAsync(chatId: Program.Messages.Chat.Id, text: Parsing.BodyHeadings +
            "\n\n" + Parsing.BodyNews + "\nЧитать далее:" + "\n" + Parsing.Links, cancellationToken: Program.Token);
        }
        public async static void NewsEveryDay()
        {
            for (int i = 0; i < Users.ListId.Count; i++)
            {
               await Program.BotClient.SendTextMessageAsync(chatId: Users.ListId[i], text: Parsing.BodyHeadings +
               "\n\n" + Parsing.BodyNews + "\nЧитать далее:" + "\n" + Parsing.Links, cancellationToken: Program.Token);    
            }
        }
        public static void InformationOutput()
        {
            Console.WriteLine($" First Name: {Program.Messages.Chat.FirstName}.\n Chat Id: {Program.Messages.Chat.Id}.\n Message: " +
            $"{Program.Messages.Text}.\n at {DateTime.Now}.");
        }
    }
}
