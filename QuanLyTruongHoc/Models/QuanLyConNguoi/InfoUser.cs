using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTruongHoc.Models.QuanLyConNguoi
{
    public abstract class InfoUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Họ và tên")]
        public string name { get; set; }

        [Required]
        [DisplayName("Ngày sinh")]
        public DateTime? ngaySinh { get; set; }

        [Required]
        [DisplayName("Giới tính")]
        public int gioiTinh { get; set; }

        [Required]
        [DisplayName("Nơi sinh")]
        public string noiSinh { get; set; }

        [Required]
        [DisplayName("Dân tộc")]
        public string danToc { get; set; }

        [Required]
        [DisplayName("Địa chỉ thường chú")]
        public string diaChiThuongTru { get; set; }
        [DisplayName("Nghề nghiệp")]
        public string ngheNghiep { get; set; }

        [Required]
        [DisplayName("CMND")]
        public string CMND { get; set; }     
    }
}
