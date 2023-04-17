using System;
using System.Collections.Generic;
using Telegrambot;

namespace TelegramBot
{
    class News
    {
        public string title;
        public string text;
        public string url;
        public static Random Rand = new Random();
        public static int RandomIndexNew(int Rand)
        {
            return Rand;
        }
        public string RenderNews()
        {
            int index = RandomIndexNew(Rand.Next(0, 99));
            SendMessage.NewsEveryDay(Storage.news[index].title + "\n" + Storage.news[index].text + "\n" + Storage.news[index].url);
            return;
        }
    }
}