using BaiTap07A.Data;
using BaiTap07A.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


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
                _db.TheLoais.Add(theloai);
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
            var theloai = _db.TheLoais.Find(id);
            return View(theloai);

        }
        [HttpPost]
        public IActionResult Edit(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                _db.TheLoais.Update(theloai);
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
            var theloai = _db.TheLoais.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }
            return View(theloai);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var theloai = _db.TheLoais.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }
            _db.TheLoais.Remove(theloai);
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
            var theloai = _db.TheLoais.Find(id);
            return View(theloai);
        }


        public IActionResult Search(string searchString)
        {
            var theLoais = _db.TheLoais.ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                theLoais = theLoais.Where(s => s.Name.Contains(searchString)).ToList();
            }

            return View("Index", theLoais);
        }
    }
}
