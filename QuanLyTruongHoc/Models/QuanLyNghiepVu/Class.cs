using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTruongHoc.Models.QuanLyNghiepVu
{
    [Table("Class")]
    public class Class
    {
        public int Id { get; set; }
        [DisplayName("Tên lớp")]
        public string Name { get; set; }
        [DisplayName("Khối")]
        public int Khoi { get; set; }
        [DisplayName("Giáo viên chủ nhiệm")]
        public int IdGiaoVien { get; set; }
        [DisplayName("Năm vào trường")]
        public int namVaoTruong { get; set; }
        [DisplayName("Năm ra trường")]
        public int namRaTruong { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
