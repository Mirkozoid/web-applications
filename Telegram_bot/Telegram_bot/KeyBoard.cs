using Telegram.Bot.Types.ReplyMarkups;

namespace KeyBoards
{
    class KeyBoard
    {
        public static ReplyKeyboardMarkup replyKeyboardMarkup;
        public static ReplyKeyboardMarkup replyKeyboardMarkupforInclude;
        public static void ReplyKeyBoardMarkup()
        {
            replyKeyboardMarkup =
             new(new[]
             {
                new KeyboardButton[] { "Подписаться на новости.", "Нет, спасибо." },
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
                new KeyboardButton[] { "Получить новость.","Остановить бота." },
             })
             {
                ResizeKeyboard = true
             };
        }
    }
}
