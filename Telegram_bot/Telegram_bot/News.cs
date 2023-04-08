using System.Collections.Generic;

namespace Telegram_Bot
{
    class News
    {
        public static string Url = "https://ru.investing.com/news/latest-news";
        public static string MainLink = "//div[contains(@class,'largeTitle')]//a[@href]";
        public static string Headings = @"//*[@id=""leftColumn""]/h1";
        public static string Tidings = @"//*[@id=""leftColumn""]/div[3]/p[1]";
        public string link;
        public string headings;
        public string mainText;
        public static List<News> news = new();
        public static List<string> textNews = new List<string>();
        public static void RenderNews()
        {
                HtmlPars.ParsNews();
                HtmlPars.BodyHeadings = HtmlPars.BodyHeadings.Replace("&mdash;", "-");
                HtmlPars.BodyHeadings = HtmlPars.BodyHeadings.Replace("&laquo;", "");
                HtmlPars.BodyHeadings = HtmlPars.BodyHeadings.Replace("&raquo;", "");
                HtmlPars.BodyHeadings = HtmlPars.BodyHeadings.Replace("&ndash;", "-");
                HtmlPars.BodyNews = HtmlPars.BodyNews.Replace("&mdash;", "-");
                HtmlPars.BodyNews = HtmlPars.BodyNews.Replace("&laquo;", "");
                HtmlPars.BodyNews = HtmlPars.BodyNews.Replace("&raquo;", "");
                HtmlPars.BodyNews = HtmlPars.BodyNews.Replace("&ndash;", "-");
                news.Add(new News()
                {
                    link = HtmlPars.Links,
                    headings = HtmlPars.BodyHeadings,
                    mainText = HtmlPars.BodyNews
                });
                textNews.Add(HtmlPars.BodyHeadings + "\n\n" + HtmlPars.BodyNews + "\n" + HtmlPars.Links);
        }
        //public static List<string> TextNews = new List<string>();
    }
}
