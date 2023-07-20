using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTruongHoc.Models.QuanLyConNguoi
{
    [Table("StudentInfo")]
    public class StudentInfo:InfoUser
    {
        [Required]
        [DisplayName("Lớp học")]
        public int IdLop { get; set; }

        [DisplayName("Họ tên cha")]

        public string? hoTenCha { get; set;}
        [DisplayName("Họ tên mẹ")]
        public string? hoTenMe { get; set; }
        [DisplayName("Nghề nghiệp cha")]
        public string? ngheNghiepCha { get; set; }
        [DisplayName("Nghề nghiệp mẹ")]
        public string? ngheNghiepMe { get; set; }
        [DisplayName("Niên khóa")]
        public string? nienKhoa { get; set; }

    }
}
