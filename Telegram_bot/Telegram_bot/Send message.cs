using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Telegrambot;

namespace TelegramBot
{
    class SendMessage
    {
        public async static void Greetings(long chatId)
        {
            await Program.BotClient.SendTextMessageAsync(chatId: chatId, Text.GreetingsText, replyMarkup: 
            KeyBoard.ButtonsSubscribeOrRefusal, cancellationToken: new CancellationToken());
        }
        public async static void SubscribeNews(long chatId)
        {
            await Program.BotClient.SendTextMessageAsync(chatId: chatId, text: Text.SubscribeNewsText,
            replyMarkup: KeyBoard.ButtonsReceiveNewsOrStopBot, cancellationToken: new CancellationToken());
        }
        public async static void StopWork(long chatId)
        {
            await Program.BotClient.SendTextMessageAsync(chatId: chatId, text: Text.StopWorkText,
            replyMarkup: new ReplyKeyboardRemove(), cancellationToken: new CancellationToken());
        }
        public async static void RandomNews(long chatId)
        {
            News text = new News();
            await Program.BotClient.SendTextMessageAsync(chatId: chatId, text: text.RenderNews(), 
            cancellationToken: new CancellationToken());
        }
        public async static void NewsEveryDay()
        {
            News text = new News();
            for (int i = 0; i < Storage.users.Count; i++)
            {
               await Program.BotClient.SendTextMessageAsync(chatId: Convert.ToInt32(Storage.users[i].id), 
               text: text.RenderNews(), cancellationToken: new CancellationToken());    
            }
        }
        public static void InformationOutput(long chatId, string firstName, string textMessage)
        {
            Console.WriteLine($" First Name: {firstName}.\n Chat Id: {chatId}.\n Message: " +
            $"{textMessage}.\n at {DateTime.Now}.");
        }
    }
}
