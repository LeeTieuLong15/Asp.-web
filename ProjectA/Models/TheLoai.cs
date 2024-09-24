using System.ComponentModel.DataAnnotations;

namespace ProjectA.Models
{
    public class TheLoai
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Khong duoc de trong ten the loai")]
        [StringLength(16, ErrorMessage = "{0} phải có độ dài phải từ {2} đến {1} ký tự.", MinimumLength = 6)]
        [Display(Name="The loai")]
        
        public string Name { get; set; }

        [Required(ErrorMessage = "Khong duoc de trong ngay tao")]
        [Display(Name = "Ngay tao")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
