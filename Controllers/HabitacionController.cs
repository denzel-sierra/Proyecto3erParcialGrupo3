using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Controllers
{
    public class HabitacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
