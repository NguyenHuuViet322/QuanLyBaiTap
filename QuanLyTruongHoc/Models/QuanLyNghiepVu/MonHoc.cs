using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTruongHoc.Models.QuanLyNghiepVu
{
    [Table("MonHoc")]
    public class MonHoc
    {
        public int Id { get; set; }
        [DisplayName("Tên môn học")]
        public string Name { get; set; }
    }
}
