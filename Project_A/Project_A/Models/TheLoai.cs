using System.ComponentModel.DataAnnotations;

namespace Project_A.Models
{
    public class TheLoai
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được để trống Tên thể loại !")]
        [StringLength(10, ErrorMessage = "{0} độ dài phải từ {2} đến {1} kí tự", MinimumLength = 8)]
        [Display(Name = "Thể loại")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Không đúng định dạng ngày !")]
        [Display(Name = "Ngày tạo")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}