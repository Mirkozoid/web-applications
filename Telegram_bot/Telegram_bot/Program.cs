using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

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

        private static Task Update(ITelegramBotClient arg1, Update arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}
