using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
