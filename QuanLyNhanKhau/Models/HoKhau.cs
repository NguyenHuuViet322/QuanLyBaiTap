using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhanKhau.Models
{
    [Table("HoKhau")]
    public class HoKhau
    {
        [Key]
        [Display(Name = "Số hộ khẩu", Prompt = "Số hộ khẩu")]
        [Required(ErrorMessage = "Thiếu số hộ khẩu")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Độ dài số hộ khẩu không hợp lệ")]
        public string? SoHoKhau { get; set; }

        [Display(Name = "Số nhà", Prompt = "Số nhà")]
        [Required(ErrorMessage = "Thiếu số nhà")]
        public string SoNha { get; set; }

        [Display(Name = "Đường", Prompt = "Đường")]
        [Required(ErrorMessage = "Thiếu tên đường")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Độ dài tên đường không hợp lệ")]
        public string Duong { get; set; }

        [Display(Name = "Phường", Prompt = "Phường")]
        [Required(ErrorMessage = "Thiếu tên phường")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Độ dài số hộ khẩu không hợp lệ")]
        public string Phuong { get; set; }

        [Display(Name = "Quận", Prompt = "Quận")]
        [Required(ErrorMessage = "Thiếu tên quận")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Độ dài số hộ khẩu không hợp lệ")]
        public string Quan { get; set; }

        public ICollection<NhanKhau>? nhanKhaus { get; set; }

        
    }
}
