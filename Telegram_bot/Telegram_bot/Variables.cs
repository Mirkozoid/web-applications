using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Varible
{
    class Variables
    {
        public static TelegramBotClient BotClient = new TelegramBotClient("6104127558:AAF00d6Blwvz4DgCVWzf8usO-xPlR1Ehz2U");
        public static CancellationToken Token;
        public static Message Messages;
        public static string BodyHeadingsNews;
        public static string BodyNews;
        public static string Links;
        public static int ID;
        public static int IDindex;
        public static string GreetingsText = "Hello, I am your financial controller" +
        "three times a day I will send you news about how things are on the market." +
        " You can also get random news at any time.\nWould you like to continue ?";
        public static string SubscribeNewsText = "You have successfully subscribed. " +
        "15:00 you will receive news from the world of exchanges, stocks and" +
        " economics.\n\nWhat do you want ?";
        public static string FarewellText = "We will be waiting for you, " +
        "click /start if you want to start again.";
        public static string StoppingWorkText = "We will be waiting for you, " +
        "click /start if you want to start again.";
        public static string MainLink = "//div[contains(@class,'GAACw')]//a[@href]";
        public static string Url = "https://www.e1.ru/";
        public static string Headings = "//div[contains(@class,'jsL2X')]//span";
        public static string News = "//div[contains(@class,'qQq9J')]//p";
        public static DateTime TimeToAlarm = DateTime.Now.Date.AddHours(15).AddMinutes(00);
        public static DateTime TimeNow;
        public static System.Timers.Timer timer = new System.Timers.Timer();
        public static ReplyKeyboardMarkup replyKeyboardMarkup;
        public static ReplyKeyboardMarkup replyKeyboardMarkupforInclude;
        public static ArrayList LinkList = new ArrayList();
        public static List<int> IdList = new List<int>();
        public static HtmlWeb Ws = new HtmlWeb();
        public static HtmlDocument Document = Ws.Load(Url);
    }
}
