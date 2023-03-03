using HtmlAgilityPack;
using System.Collections;
using Telegram.Bot.Types.ReplyMarkups;

namespace Varible
{
    class Variables
    {
        public static string BodyHeadingsNews;
        public static string BodyNews;
        public static string Links;
        public static string GreetingsText = "Hello, I am your financial controller" +
        "three times a day I will send you news about how things are on the market." +
        " You can also get random news at any time.\nWould you like to continue ?";
        public static string SubscribeNewsText = "You have successfully subscribed. " +
        "Every day at 10:00," + " 15:00 and 20:00 you will receive news from the world of" +
        " exchanges, stocks and economics.\n\nWhat do you want ?";
        public static string FarewellText = "We will be waiting for you, " +
        "click /start if you want to start again.";
        public static string StoppingWorkText = "We will be waiting for you, " +
        "click /start if you want to start again.";
        public static string MainLink = "//div[contains(@class,'GAACw')]//a[@href]";
        public static string Url = "https://www.e1.ru/";
        public static string Headings = "//div[contains(@class,'jsL2X')]//span";
        public static string News = "//div[contains(@class,'qQq9J')]//p";
        public static ReplyKeyboardMarkup replyKeyboardMarkup;
        public static ReplyKeyboardMarkup replyKeyboardMarkupforInclude;
        public static ArrayList LinkList = new ArrayList();
        public static HtmlWeb Ws = new HtmlWeb();
        public static HtmlDocument Document = Ws.Load(Url);
    }
}
