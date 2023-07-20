using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTruongHoc.Models.QuanLyCSVC
{
    [Table("Device")]
    public class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên thiết bị")]
        [Required]
        public string tenCoSoVatChat { get; set; }

        [Display(Name = "Số lượng")]
        [Required]
        public int soLuong { get; set; }

        [Display(Name = "Hiện trạng sử dụng")]
        [Required]
        public string hienTrang { get; set; }

        [Display(Name = "Ghi chú")]
        public string? ghiChu { get; set; }
    }
}
