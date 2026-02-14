using Microsoft.AspNetCore.Mvc;

namespace WebTranslator.Controllers
{
    public class TranslationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
