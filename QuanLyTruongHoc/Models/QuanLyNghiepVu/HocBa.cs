using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTruongHoc.Models.QuanLyNghiepVu
{
    [Table("HocBa")]
    public class HocBa
    {
        public int Id { get; set; }
        public int IdHocSinh { get; set; }
        public bool trangThai { get; set; }
    }
}
