using BaiKiemTra03_01.Models;
using Microsoft.EntityFrameworkCore;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<NhanVien> NhanVien { get; set; }
    public DbSet<PhongBan> PhongBan { get; set; }

    // Data/ApplicationDbContext.cs
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Cấu hình khóa chính
        modelBuilder.Entity<NhanVien>()
            .HasKey(nv => nv.MaNhanVien);

        modelBuilder.Entity<PhongBan>()
            .HasKey(pb => pb.MaPhongBan);

        // Cấu hình khóa ngoại
        modelBuilder.Entity<NhanVien>()
            .HasOne(nv => nv.PhongBan)
            .WithMany(pb => pb.NhanViens)
            .HasForeignKey(nv => nv.MaPhongBan);

        modelBuilder.Entity<PhongBan>()
            .HasOne(pb => pb.PhongBanQuanLy)
            .WithMany()
            .HasForeignKey(pb => pb.MaPhongBanQuanLy);

       
        modelBuilder.Entity<PhongBan>().HasData(
            new PhongBan { MaPhongBan = 1, TenPhongBan = "Phòng Nhân sự", SoLuongNhanVien = 10 },
            new PhongBan { MaPhongBan = 2, TenPhongBan = "Phòng Kinh doanh", SoLuongNhanVien = 15 }
        );

        modelBuilder.Entity<NhanVien>().HasData(
            new NhanVien { MaNhanVien = 1, TenNhanVien = "Nguyễn Đức Tuấn", ChucVu = "Nhân viên", MaPhongBan = 1, NgayBatDauLamViec = new DateTime(2020, 1, 1) },
            new NhanVien { MaNhanVien = 2, TenNhanVien = "Trần Thị Hạnh", ChucVu = "Trưởng phòng", MaPhongBan = 2, NgayBatDauLamViec = new DateTime(2019, 5, 1) }
        );
    }

}
