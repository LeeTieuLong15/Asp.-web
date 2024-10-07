using ProjectA.Data;
using ProjectA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjectA.Controllers
{
    [Area("Admin")]
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TheLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var theLoai = _db.TheLoai.ToList();
            ViewBag.TheLoai = theLoai;  
            return View(theLoai);
        }

        // Thêm 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TheLoai theLoai)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.TheLoai.Add(theLoai);
                // Lưu lại
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // Sửa
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theLoai = _db.TheLoai.Find(id);
            return View(theLoai);
        }

        [HttpPost]
        public IActionResult Edit(TheLoai theLoai)
        {
            if (ModelState.IsValid)
            {
                _db.TheLoai.Update(theLoai);
                // Lưu lại
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // Xóa

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var theLoai = _db.TheLoai.Find(id);
            if (theLoai == null)
            {
                return NotFound();
            }

            return View(theLoai);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var theLoai = _db.TheLoai.Find(id);
            if (theLoai == null)
            {
                return NotFound();
            }

            _db.TheLoai.Remove(theLoai);
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
            var theLoai = _db.TheLoai.Find(id);
            return View(theLoai);
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
