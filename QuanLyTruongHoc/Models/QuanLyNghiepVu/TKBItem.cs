using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTruongHoc.Models.QuanLyNghiepVu
{
    [Table("TKBItem")]
    public class TKBItem
    {
        public int Id { get; set; }
        public int IdTKB { get; set; }
        [DisplayName("Giáo viên giảng dạy")]
        public int IdGiaoVien { get; set; }
        [DisplayName("Môn học")]
        public int IdMonHoc { get; set; }
        [DisplayName("Ngày học")]
        public string day { get; set; }
        [DisplayName("Tiết học")]
        public int tietHoc { get; set; }
        public int IdLop { get; set; }
    }
}
