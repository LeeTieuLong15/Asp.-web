using System.ComponentModel.DataAnnotations;

namespace BaiTap07A.Models
{
    public class TheLoai
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Khong duoc de trong ten the loai")]
        [StringLength(10, ErrorMessage = "{0} phải có độ dài phải từ {2} đến {1} ký tự.", MinimumLength = 8)]
        [Display(Name="The loai")]
        
        public string Name { get; set; }

        [Required(ErrorMessage = "Khong duoc de trong ngay tao")]
        [Display(Name = "Ngay tao")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
