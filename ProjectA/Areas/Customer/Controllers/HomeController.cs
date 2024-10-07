using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Thêm namespace này
using ProjectA.Data; // Thêm namespace để sử dụng ApplicationDbContext
using ProjectA.Models;
using System.Diagnostics;

namespace ProjectA.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db; // Khai báo DbContext

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db; // Khởi tạo DbContext
        }

        public IActionResult Index()
        {
            // Lấy danh sách sản phẩm từ cơ sở dữ liệu
            var sanpham = _db.SanPham.Include(sp => sp.TheLoai).ToList(); // Bao gồm thể loại
            return View(sanpham); // Truyền danh sách sản phẩm vào view
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
