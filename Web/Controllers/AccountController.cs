using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Register(string username, string email, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email)  || string.IsNullOrEmpty(password))
            {
                return BadRequest();
            }
            using (var db = new MyAppContext())
            {
                var user = new User { Username = username, Email = email, Password = password };
                db.Users.Add(user);
                await db.SaveChangesAsync();
            }
            // Добавить отправку кода подтверждения на почту
            return RedirectToAction("AfterRegister", "Account");
        }
        public IActionResult AfterRegister()
        {
            return View();
        }
    }
}