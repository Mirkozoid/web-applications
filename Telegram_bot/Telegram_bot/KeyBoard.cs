using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    class KeyBoard
    {
        public static ReplyKeyboardMarkup ButtonsSubscribeOrRefusal =
             new(new[]
             { new KeyboardButton[] { "Подписаться на новости.", "Нет, спасибо." }, })
             { ResizeKeyboard = true};
        public static ReplyKeyboardMarkup ButtonsReceiveNewsOrStopBot =
             new(new[]
             { new KeyboardButton[] { "Получить новость.","Остановить бота." }, })
             { ResizeKeyboard = true };
    }
}
