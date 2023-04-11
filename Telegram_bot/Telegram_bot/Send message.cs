using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram_Bot
{
    class SendMessage
    {
        public static long ChatId = User.users.Find(User => User.id == Program.Messages.Chat.Id).id;
        public async static void Greetings()
        {
            await Program.BotClient.SendTextMessageAsync(chatId: ChatId, Text.GreetingsText, replyMarkup: 
            KeyBoard.ButtonsSubscribeOrRefusal, cancellationToken: new CancellationToken());
        }
        public async static void SubscribeNews()
        {
            await Program.BotClient.SendTextMessageAsync(chatId: ChatId, text: Text.SubscribeNewsText,
            replyMarkup: KeyBoard.ButtonsReceiveNewsOrStopBot, cancellationToken: new CancellationToken());
        }
        public async static void StopWork()
        {
            await Program.BotClient.SendTextMessageAsync(chatId: ChatId, text: Text.StopWorkText,
            replyMarkup: new ReplyKeyboardRemove(), cancellationToken: new CancellationToken());
        }
        public async static void RandomNews()
        {
            await Program.BotClient.SendTextMessageAsync(chatId: ChatId, text: News.textNews[6], 
            cancellationToken: new CancellationToken());
        }
        public async static void NewsEveryDay()
        {
            for (int i = 0; i < User.users.Count; i++)
            {
               await Program.BotClient.SendTextMessageAsync(chatId: Convert.ToInt32(User.users[i].id), 
               text: News.textNews[0], cancellationToken: new CancellationToken());    
            }
        }
        public static void InformationOutput()
        {
            Console.WriteLine($" First Name: {Program.Messages.Chat.FirstName}.\n Chat Id: {Program.Messages.Chat.Id}.\n Message: " +
            $"{Program.Messages.Text}.\n at {DateTime.Now}.");
        }
    }
}
