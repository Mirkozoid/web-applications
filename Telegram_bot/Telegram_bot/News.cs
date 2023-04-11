using System.Collections.Generic;

namespace Telegram_Bot
{
    class News
    {
        public static string Url = "https://lenta.ru/rubrics/economics/markets/";
        public static string MainLink = @"//*[@id=""body""]/div[2]/div[3]/main/div/section";
        public static string Tidings = "//div[contains(@class,'topic-body__content')]/p";
        //*[@id="leftColumn"]/div[3]
        //*[@id="leftColumn"]/div[3]/text()[2]
        //*[@id="leftColumn"]/div[3]/text()[3]
        //div[contains(@class,'topic-body _news')]//p]"
        //@"//*[@id="body"]/div[2]/div[3]/main/div/section/ul"
        //*[@id="overlap-manager-root"]/div/div/div[1]/div/div[2]/div[1]/div[2]/div/article
        public static List<News> news = new();
        public string link;
        public string mainText;
        public static List<string> textNews = new List<string>();
        public static void RenderNews()
        {
            for (int i = 0; i < CreatLinks.LinkList.Count; i++)
            {
                HtmlPars.ParsNews();
                HtmlPars.BodyNews = HtmlPars.BodyNews.Replace("&mdash;", "-");
                HtmlPars.BodyNews = HtmlPars.BodyNews.Replace("&laquo;", "");
                HtmlPars.BodyNews = HtmlPars.BodyNews.Replace("&raquo;", "");
                HtmlPars.BodyNews = HtmlPars.BodyNews.Replace("&ndash;", "-");
                HtmlPars.BodyNews = HtmlPars.BodyNews.Replace("&copy; Reuters.", "");
                news.Add(new News()
                {
                    link = HtmlPars.Links,
                    mainText = HtmlPars.BodyNews
                });
                textNews.Add(HtmlPars.BodyNews + "\n" + HtmlPars.Links);
            }
        }
    }
}
