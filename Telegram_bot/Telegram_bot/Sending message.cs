using IDLinks;
using KeyBoards;
using NewsContainer;
using Parsing;
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
            await Program.BotClient.SendTextMessageAsync(chatId: Program.Messages.Chat.Id, text: ParsingHTML.BodyHeadings +
               "\n\n" + ParsingHTML.BodyNews + "\nЧитать далее:" + "\n" + ParsingHTML.Links, cancellationToken: Program.Token);
        }
        public async static void NewsEveryDay()
        {
            DictionaryLinksNews.LinkList.RemoveAt(0);
            for (int i = 0; i < Users.ListUserID.Count; i++)
            {
               await Program.BotClient.SendTextMessageAsync(chatId: Users.ListUserID[i], text: ParsingHTML.BodyHeadings +
               "\n\n" + ParsingHTML.BodyNews + "\nЧитать далее:" + "\n" + ParsingHTML.Links, cancellationToken: Program.Token);    
            }
        }
        public static void InformationOutput()
        {
            Console.WriteLine($" First Name: {Program.Messages.Chat.FirstName}.\n Chat Id: {Program.Messages.Chat.Id}.\n Message: " +
            $"{Program.Messages.Text}.\n at {DateTime.Now}.");
        }
    }
}
