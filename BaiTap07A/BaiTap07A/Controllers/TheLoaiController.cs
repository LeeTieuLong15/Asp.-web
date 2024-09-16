using BaiTap07A.Data;
using BaiTap07A.Models;
using Microsoft.AspNetCore.Mvc;


namespace BaiTap07A.Controllers
{
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TheLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var theloai = _db.TheLoais.ToList();
            ViewBag.TheLoais = theloai;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TheLoai theloai)
        {
            // Thêm thông tin vào bảng TheLoai
            _db.TheLoais.Add(theloai);
            // Lưu lại
            _db.SaveChanges();
            return View();
        }
    }
}
