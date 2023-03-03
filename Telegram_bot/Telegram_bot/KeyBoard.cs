using Telegram.Bot.Types.ReplyMarkups;
using Varible;

namespace KeyBoards
{
    class KeyBoard : Variables
    {
        public static void ReplyKeyBoardMarkup()
        {
            replyKeyboardMarkup =
             new(new[]
             {
                new KeyboardButton[] { "Subscribe to the news.", "No thanks." },
             })
             {
                ResizeKeyboard = true
             };
        }
        public static void ReplyKeyBoardMarkupforInclude()
        {
            replyKeyboardMarkupforInclude =
             new(new[]
             {
                new KeyboardButton[] { "Get random news.","Stop working." },
             })
             {
                ResizeKeyboard = true
             };
        }
    }
}
