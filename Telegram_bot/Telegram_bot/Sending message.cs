using System;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram_Bot
{
    class SendingMessage
    {
        public async static void Greetings()
        {
            await Program.BotClient.SendTextMessageAsync(chatId: Program.Messages.Chat.Id, Text.GreetingsText,replyMarkup: 
            KeyBoard.ButtonsSubscribeOrRefusal, cancellationToken: Program.Token);
        }
        public async static void SubscribeNews()
        {
            await Program.BotClient.SendTextMessageAsync(chatId: Program.Messages.Chat.Id, text: Text.SubscribeNewsText,
            replyMarkup: KeyBoard.ButtonsReceiveNewsOrStopBot, cancellationToken: Program.Token);
        }
        public async static void StopWork()
        {
            await Program.BotClient.SendTextMessageAsync(chatId: Program.Messages.Chat.Id, text: Text.StopWorkText,
            replyMarkup: new ReplyKeyboardRemove(), cancellationToken: Program.Token);
        }
        public async static void RandomNews()
        {
            await Program.BotClient.SendTextMessageAsync(chatId: Program.Messages.Chat.Id, text: News.news[1].headings + 
            "\n\n" + News.news[1].mainText+ "\n" + News.news[1].link, cancellationToken: Program.Token);
            Console.WriteLine(News.news[0].mainText);
        }
        public async static void NewsEveryDay()
        {
            for (int i = 0; i < User.ListUserID.Count; i++)
            {
               await Program.BotClient.SendTextMessageAsync(chatId: User.ListUserID[i], text: News.news[0].headings +
               "\n\n" + News.news[0].mainText + "\n" + News.news[0].link, cancellationToken: Program.Token);    
            }
        }
        public static void InformationOutput()
        {
            Console.WriteLine($" First Name: {Program.Messages.Chat.FirstName}.\n Chat Id: {Program.Messages.Chat.Id}.\n Message: " +
            $"{Program.Messages.Text}.\n at {DateTime.Now}.");
        }
    }
}
