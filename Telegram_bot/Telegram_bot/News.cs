using System.Collections.Generic;

namespace NewsContainer
{
    class News
    {
        public static string Url = "https://ru.investing.com/news/latest-news";
        public static string MainLink = "//div[contains(@class,'largeTitle')]//a[@href]";
        public static string Headings = @"//*[@id=""leftColumn""]/h1";
        public static string Tidings = @"//*[@id=""leftColumn""]/div[3]/p[1]";
        //public static List<string> TextNews = new List<string>();
    }
}
