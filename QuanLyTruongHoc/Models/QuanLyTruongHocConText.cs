using Microsoft.EntityFrameworkCore;
using QuanLyTruongHoc.Models.QuanLyConNguoi;
using QuanLyTruongHoc.Models.QuanLyCSVC;
using QuanLyTruongHoc.Models.QuanLyNghiepVu;

namespace QuanLyTruongHoc.Models
{
    public class QuanLyTruongHocConText : DbContext
    {
        public DbSet<StudentInfo> Students { get; set; }
        public DbSet<TeacherInfo> Teachers { get; set; }
        public DbSet<Device> devices { get; set; }
        public DbSet<Class> classes { get; set; }
        public DbSet<GradeProfile> gradeProfiles { get; set; }
        public DbSet<HocBa> hocBas { get; set; }
        public DbSet<KiThi> kiThis { get; set; }
        public DbSet<MonHoc> monHocs { get; set; }
        public DbSet<TKB> tKBs { get; set; }
        public DbSet<TKBItem> tKBItems { get; set; }
        public DbSet<GiaoVienMonHoc> giaoVienMonHocs { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<DeviceBorrow> deviceBorrows { get; set; }
        public DbSet<KiThiLopHoc> kiThiLopHocs { get; set; }
        public DbSet<Note> notes { get; set; }
        public DbSet<ThongBao> thongBaos { get; set; }  
        public DbSet<ThongBaoLink> thongBaoLinks { get; set; }
        public QuanLyTruongHocConText(DbContextOptions<QuanLyTruongHocConText> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
