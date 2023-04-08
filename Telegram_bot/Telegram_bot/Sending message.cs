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
            int chatId = Convert.ToInt32(User.users.Find(User => User.id == Program.Messages.Chat.Id));
            await Program.BotClient.SendTextMessageAsync(chatId: User.users[chatId].id, text: News.textNews[0], cancellationToken: Program.Token);
        }
        public async static void NewsEveryDay()
        {
            for (int i = 0; i < User.users.Count; i++)
            {
               await Program.BotClient.SendTextMessageAsync(chatId: User.users[i].id, text: News.textNews[0], cancellationToken: Program.Token);    
            }
        }
        public static void InformationOutput()
        {
            Console.WriteLine($" First Name: {Program.Messages.Chat.FirstName}.\n Chat Id: {Program.Messages.Chat.Id}.\n Message: " +
            $"{Program.Messages.Text}.\n at {DateTime.Now}.");
        }
    }
}
