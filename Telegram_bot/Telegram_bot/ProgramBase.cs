namespace Telegram_Bot
{
    internal class ProgramBase
    {
        private static IReplyMarkup GetButtons(List<KeyboardButton>)
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{new KeyboardButton { Text = "Include tips" }, new KeyboardButton { Text = "No thanks" } }
                }
            };
        }
    }
}