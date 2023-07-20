using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTruongHoc.Models.QuanLyNghiepVu
{
    [Table("GradeProfile")]
    public class GradeProfile
    {
        public int Id { get; set; }
        public int IdKiThi { get; set; }
        public int IdHocSinh { get; set; }
        public float Diem { get; set; }
        public DateTime createTime { get; set; }
    }
}
