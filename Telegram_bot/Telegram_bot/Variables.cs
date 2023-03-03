using HtmlAgilityPack;
using System.Collections;

namespace Varible
{
    class Variables
    {
        public static string BodyHeadingsNews;
        public static string BodyNews;
        public static string Links;
        public static string MainLink = "//div[contains(@class,'GAACw')]//a[@href]";
        public static string Url = "https://www.e1.ru/";
        public static string Headings = "//div[contains(@class,'jsL2X')]//span";
        public static string News = "//div[contains(@class,'qQq9J')]//p";
        public static ArrayList LinkList = new ArrayList();
        public static HtmlWeb Ws = new HtmlWeb();
    }
}
