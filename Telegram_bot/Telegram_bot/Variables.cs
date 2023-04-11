using System;

namespace Telegram_Bot
{
    class Variables
    {
        public static Random Rand = new Random();
        public static int RandomIndexNew()
        {
            return Rand.Next(0, 99);
        }
    }
}
