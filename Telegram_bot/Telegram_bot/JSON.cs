using Newtonsoft.Json;
using System.IO;

namespace Telegrambot
{
    public class ItemJSON
    {
        public string tokenBot { get; set; }
        public string tokenAPI { get; set; }
        public static string JsonString = File.ReadAllText(@"C:\Users\User\Desktop\Proj\Labs\web-applications\Telegram_bot\Telegram_bot\tokens.json");
        public static ItemJSON itemJSON = JsonConvert.DeserializeObject<ItemJSON>(JsonString)!;
    }
}
