using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_01.Models
{
    public class PhongBan
    {
        [Key]
        public int MaPhongBan { get; set; }
        public string TenPhongBan { get; set; }
        public int SoLuongNhanVien { get; set; }
        public int? MaPhongBanQuanLy { get; set; }


        public PhongBan PhongBanQuanLy { get; set; }
        public ICollection<NhanVien> NhanViens { get; set; }
    }
}
