using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ProjectB.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectB.Models
{
    public class GioHangViewModel
    {
        public IEnumerable<GioHang> DsGioHang { get; set; }


        public HoaDon HaoDon { get; set; }
    }
}
