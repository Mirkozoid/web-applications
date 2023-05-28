using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Register(string username, string email, string password)
        {
            // Проверка корректности введенных данных
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email)  || string.IsNullOrEmpty(password))
            {
                // Возвращаем ошибку, если данные некорректны
                return BadRequest();
            }

            // Сохранение информации о новом пользователе в базе данных
            // ...

            // Отправка письма подтверждения на указанный email
            // ...

            // Перенаправление пользователя на страницу успешной регистрации
            return RedirectToAction("AfterRegister", "Account");
        }

        public IActionResult AfterRegister()
        {
            return View();
        }
    }
}