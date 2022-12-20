using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhanKhau.Models
{
    [Table("History")]
    public class HistoryItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdItem { get; set; }

        public string HoatDong { get; set; }

        public string SoHoKhau { get; set; }

        public DateTime NgayThayDoi { get; set; }

        public string GhiChu { get; set; }

        public int DoiTuong { get; set; }

        [ForeignKey("DoiTuong")]
        public NhanKhau DoiTuongO { get; set; }
    }
}
