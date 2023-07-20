using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTruongHoc.Models.QuanLyCSVC
{
    [Table("DeviceBorrow")]
    public class DeviceBorrow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int IdDevice { get; set; }
        public int IdUser { get; set; }
        public int IdDoiTuong { get; set; }
        public int SoLuong { get; set; }
        public int Status { get; set; }
        public DateTime ngayMuon { get; set; }
    }
}
