using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTruongHoc.Models.QuanLyNghiepVu
{
    [Table("ThongBaoLopHoc")]
    public class ThongBaoLink
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int IdThongBao { get; set; }
        public int IdLopHoc { get; set; }
        public int IdHocSinh { get; set; }
        public int IdGiaoVienDt { get; set; }
    }
}
