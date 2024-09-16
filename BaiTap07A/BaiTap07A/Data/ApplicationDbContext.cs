using Microsoft.EntityFrameworkCore;
using BaiTap07A.Models;
namespace BaiTap07A.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {

        }

        public DbSet<TheLoai> TheLoais { get; set; }

    }
}
