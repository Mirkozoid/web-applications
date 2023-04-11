using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;

namespace Telegram_Bot
{
    class NewsAPI
    {
        public static void SearchNews()
        {
            var newsApiClient = new NewsApiClient("3f3d1b21c67d428789637f10eca4787d");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "business",
                SortBy = SortBys.Popularity,
                Language = Languages.RU,
                From = new DateTime(2023, 3, 28)
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                Console.WriteLine(articlesResponse.TotalResults);
                foreach (var article in articlesResponse.Articles)
                {
                    News.textNews.Add(article.Title + "\n" + article.Description + "\n" + article.Url);
                }
            }
        }
    }
}
