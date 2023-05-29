using Newtonsoft.Json;
using System.IO;

namespace Telegrambot
{
    public class ItemJSON
    {
        public string urlBackFirst { get; set; }
        public string urlBackSecond { get; set; }
        public string urlSiteBananas { get; set; }
        public string urlSiteLions { get; set; }
        public string urlSiteFish { get; set; }
        public string urlSiteFlowers { get; set; }
        public static string JsonString = File.ReadAllText(@"C:\Users\User\Desktop\Proj\Labs\web-applications\Web\url.json");
        public static ItemJSON itemJSON = JsonConvert.DeserializeObject<ItemJSON>(JsonString)!;
    }
}
