using Microsoft.EntityFrameworkCore;

namespace QuanLyNhanKhau.Models
{
    public class QuanLyNhanKhauConText : DbContext
    {
        public DbSet<HoKhau> hoKhaus { get; set; }
        public DbSet<NhanKhau> nhanKhaus { get;set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<HistoryItem> historyItems { get; set; }

        public QuanLyNhanKhauConText(DbContextOptions<QuanLyNhanKhauConText> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoKhau>()
                .HasMany<NhanKhau>(g => g.nhanKhaus);

            modelBuilder.Entity<NhanKhau>()
                .HasOne<HoKhau>(g => g.hoKhau)
                .WithMany(s => s.nhanKhaus)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HistoryItem>()
                .HasOne<NhanKhau>(g => g.DoiTuongO);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
