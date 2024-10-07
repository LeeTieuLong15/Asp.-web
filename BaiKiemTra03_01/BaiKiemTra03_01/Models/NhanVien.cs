using System;
using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_01.Models
{
    public class NhanVien
    {
        [Key]
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string ChucVu { get; set; }
        public int MaPhongBan { get; set; }
        public DateTime NgayBatDauLamViec { get; set; }

        public PhongBan PhongBan { get; set; }
    }
}
