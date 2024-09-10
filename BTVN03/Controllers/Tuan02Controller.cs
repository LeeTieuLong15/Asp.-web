using Microsoft.AspNetCore.Mvc;

namespace BTVN03.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Lê Phước Hậu";
            ViewBag.MSSV = "1822020129";
            ViewData["Nam"] = "Năm 2024";

            return View();
        }
    }
}
