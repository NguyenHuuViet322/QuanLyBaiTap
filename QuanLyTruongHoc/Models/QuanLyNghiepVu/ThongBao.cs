using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTruongHoc.Models.QuanLyNghiepVu
{
    [Table("ThongBao")]
    public class ThongBao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int IdGiaoVien { get; set; }
        public int loaiThongBao { get; set; }
        public DateTime dateCreated { get; set; }
        public string title { get; set; }
        public string content { get; set; }
    }
}
