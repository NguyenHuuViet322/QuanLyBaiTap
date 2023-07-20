using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTruongHoc.Models.QuanLyNghiepVu
{
    [Table("TKB")]
    public class TKB
    {
        public int Id { get; set; }
        [DisplayName("Kì học")]
        public string KiHoc { get; set; }
        [DisplayName("Khối học")]
        public string KhoiHoc { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime DateCreate { get; set; }
        [DisplayName("Trạng thái")]
        public bool status { get; set; }

        [NotMapped]
        public TKBItem[] tkbList { get; set; }
    }
}
