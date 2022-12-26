using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhanKhau.Models
{
    [Table("History")]
    public class HistoryItem
    {
        public HistoryItem(string hoatDong, string soHoKhau, DateTime ngayThayDoi, string ghiChu, int? doiTuong)
        {
            HoatDong = hoatDong;
            SoHoKhau = soHoKhau;
            NgayThayDoi = ngayThayDoi;
            GhiChu = ghiChu;
            DoiTuong = doiTuong;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdItem { get; set; }

        [Display(Name = "Hoạt động")]
        public string HoatDong { get; set; }

        [Display(Name = "Hộ khẩu thay đổi")]
        public string SoHoKhau { get; set; }

        [Display(Name = "Ngày xảy ra")]
        public DateTime NgayThayDoi { get; set; }

        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        [Display(Name = "Đối tượng chuyển")]
        public int? DoiTuong { get; set; }

        [ForeignKey("DoiTuong")]
        public NhanKhau? DoiTuongO { get; set; }
    }
}
