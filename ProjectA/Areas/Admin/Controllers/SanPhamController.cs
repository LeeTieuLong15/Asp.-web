using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectA.Data;
using ProjectA.Models;

namespace ProjectA.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SanPhamController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").ToList();
            return View(sanpham);
        }

        [HttpGet]
        public IActionResult Upsert(int id)
        {
            // Tạo đối tượng sản phẩm mới
            SanPham sanpham = new SanPham();

            // Lấy danh sách thể loại từ database để hiển thị trong dropdown
            IEnumerable<SelectListItem> dstheloai = _db.TheLoai.Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                }
            );

            ViewBag.DSTheLoai = dstheloai;

            // Kiểm tra nếu id = 0, tức là thêm mới sản phẩm
            if (id == 0)
            {
                return View(sanpham); // Trả về View với sản phẩm rỗng
            }
            else
            {
                // Tìm sản phẩm cần chỉnh sửa, bao gồm thông tin thể loại
                sanpham = _db.SanPham.Include("TheLoai").FirstOrDefault(sp => sp.Id == id);

                if (sanpham == null)
                {
                    return NotFound(); // Trả về lỗi nếu không tìm thấy sản phẩm
                }

                return View(sanpham); // Trả về View với sản phẩm cần chỉnh sửa
            }
        }

        [HttpPost]
        public IActionResult Upsert(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra nếu sản phẩm có ID = 0 thì là thêm mới sản phẩm
                if (sanpham.Id == 0)
                {
                    _db.SanPham.Add(sanpham); // Thêm mới sản phẩm
                }
                else
                {
                    _db.SanPham.Update(sanpham); // Cập nhật sản phẩm hiện có
                }

                _db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                TempData["SuccessMessage"] = "Thao tác thành công!"; // Hiển thị thông báo thành công
                return RedirectToAction("Index"); // Chuyển hướng về trang danh sách sản phẩm
            }

            // Nếu có lỗi trong model, trả về View với dữ liệu hiện tại
            IEnumerable<SelectListItem> dstheloai = _db.TheLoai.Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                }
            );
            ViewBag.DSTheLoai = dstheloai;

            return View(sanpham); // Trả về View nếu có lỗi validation
        }




        [HttpPost]
        public IActionResult Delete(int id)
        {
            var sanpham = _db.SanPham.FirstOrDefault(sp => sp.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            _db.SanPham.Remove(sanpham);
            _db.SaveChanges();
            return Json(new { success = true });
        }


    }

}
