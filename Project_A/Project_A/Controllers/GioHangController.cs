﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_A.Data;
using Project_A.Models;
using System.Security.Claims;

namespace Project_A.Controllers
{
    [Area("Customer")]
    public class GioHangController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GioHangController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);

            IEnumerable<Giohang> dsGioHang = _db.Giohang.Include("SanPham").Where(gh => gh.ApplicationUserId == claim.Value).ToList();


            return View(dsGioHang);
        }
    }
}