using ProjectB.Data;
using ProjectB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;


namespace ProjectB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TheLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }

  
        public IActionResult Index()
        {
            var theloai = _db.TheLoai.ToList();
            ViewBag.TheLoais = theloai;
            return View();
        }

  
    

        // Thêm 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.TheLoai.Add(theloai);
                // Lưu lại
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }


        //Sửa
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoai.Find(id);
            return View(theloai);

        }
        [HttpPost]
        public IActionResult Edit(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                _db.TheLoai.Update(theloai);
                // Lưu lại
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

        //Xóa
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoai.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }
            return View(theloai);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var theloai = _db.TheLoai.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }
            _db.TheLoai.Remove(theloai);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }


        public IActionResult Search(string searchString)
        {
            var theLoai = _db.TheLoai.ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                theLoai = theLoai.Where(s => s.Name.Contains(searchString)).ToList();
            }

            return View("Index", theLoai);
        }
    }
}
