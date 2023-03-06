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
