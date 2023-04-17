using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;
using Telegrambot;

namespace TelegramBot
{
    class NewsAPI
    {
        public static void SearchNews()
        {
            var newsApiClient = new NewsApiClient(System.IO.File.ReadAllText(@"C:\Users\User\Desktop\Proj\Labs\web-applications\Telegram_bot\tokenAPI.txt"));
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "business",
                SortBy = SortBys.Popularity,
                Language = Languages.RU,
                From = DateTime.Now.AddDays(-15)
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                Console.WriteLine(articlesResponse.TotalResults);
                foreach (var article in articlesResponse.Articles)
                {
                    Storage.news.Add(new News() 
                    { 
                        title = article.Title + "\n", 
                        text = article.Description + "\n", 
                        url = article.Url, 
                    });
                }
            }
        }
    }
}
