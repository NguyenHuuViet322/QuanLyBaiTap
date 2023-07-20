using QuanLyTruongHoc.Models.QuanLyNghiepVu;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTruongHoc.Models.QuanLyConNguoi
{
    [Table("TeacherInfo")]
    public class TeacherInfo:InfoUser
    {
        [DisplayName("Bằng cấp")]
        public string bangCap { get; set; }

        [DisplayName("Chuyên môn")]
        public string chuyenMon { get; set; }

        [DisplayName("Chức vụ")]
        public int phanQuyen { get; set; }
        [DisplayName("Lương")]
        public int luong { get; set; }
    }
}
