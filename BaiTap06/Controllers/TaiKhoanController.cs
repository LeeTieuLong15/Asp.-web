using Microsoft.AspNetCore.Mvc;
using BaiTap06.Models;

namespace BaiTap06.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangKy(TaiKhoanViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Xử lý đăng ký ở đây
                ViewBag.Message = "Đăng ký thành công!";
            }
            return View(model);
        }
    }
}
