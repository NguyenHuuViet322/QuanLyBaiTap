using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTruongHoc.Models.QuanLyNghiepVu
{
    [Table("KiThiLopHoc")]
    public class KiThiLopHoc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int IdKiThi { get; set; }
        [DisplayName("Giáo viên giảng dạy")]
        public int IdLopHoc { get; set; }
        public int IdGiaoVien { get; set; }
    }
}
