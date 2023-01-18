using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhanKhau.Models
{
    [Table("NhanKhau")]
    public class NhanKhau
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdNhanKhau { get; set; }

        [Display(Name = "Họ và tên", Prompt = "Họ và tên")]
        [Required(ErrorMessage = "Thiếu họ tên")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Độ dài họ tên phải trong khoảng 3 đến 25 kí tự")]
        public string HoTen { get; set; }

        [Display(Name = "Giới tính", Prompt = "Giới tính")]
        [Required(ErrorMessage = "Thiếu giới tính")]
        public string GioiTinh { get; set; }

        [Display(Name = "Bí danh", Prompt = "Bí danh")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Độ dài họ tên phải trong khoảng 3 đến 25 kí tự")]
        public string BiDanh { get; set; }

        [Display(Name = "Ngày sinh", Prompt = "Ngày sinh")]
        [Required(ErrorMessage = "Thiếu họ tên")]
        public DateTime NgaySinh { get; set; }

        [Display(Name = "Nơi sinh", Prompt = "Nơi sinh")]
        [Required(ErrorMessage = "Thiếu nơi sinh")]
        public string NoiSinh { get; set; }

        [Display(Name = "Nguyên quán", Prompt = "Nguyên quán")]
        [Required(ErrorMessage = "Thiếu nguyên quán")]
        public string NguyenQuan { get; set; }

        [Display(Name = "Dân tộc", Prompt = "Dân tộc")]
        [Required(ErrorMessage = "Thiếu dân tộc")]
        public string DanToc { get; set; }

        [Display(Name = "Nghề nghiệp", Prompt = "Nghề nghiệp")]
        [Required(ErrorMessage = "Thiếu nghề nghiệp")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Độ dài nghề nghiệp phải trong khoảng 3 đến 25 kí tự")]
        public string NgheNghiep { get; set; }

        [Display(Name = "Nơi làm việc", Prompt = "Nơi làm việc")]
        [Required(ErrorMessage = "Thiếu nơi làm việc")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Độ dài nơi làm việc phải trong khoảng 3 đến 50 kí tự")]
        public string NoiLamViec { get; set; }

        [Display(Name = "Số CMND/CCCD", Prompt = "Số CMND/CCCD")]
        [Required(ErrorMessage = "Thiếu số CMND/CCCD")]
        [StringLength(13, ErrorMessage = "Độ dài CMND không được quá 13 kí tự")]
        public string CMND { get; set; }

        [Display(Name = "Ngày cấp CMND", Prompt = "Nơi cấp CMND")]
        public DateTime? NgayCapCMND { get; set; }

        [Display(Name = "Nơi cấp CMND/CCCD", Prompt = "Nơi cấp CMND/CCCD")]
        public string? NoiCapCMND { get; set; }

        [Display(Name = "Ngày tháng năm đăng kí thường trú", Prompt = "Ngày tháng năm đăng kí thường trú")]
        [Required(ErrorMessage = "Thiếu số thông tin")]
        public DateTime NgayDangKi { get; set; }

        [Display(Name = "Địa chỉ thường trú trước khi chuyển đến", Prompt = "Địa chỉ thường chú trước khi chuyển đến")]
        public string DiaChiTruoc { get; set; }

        [Display(Name = "Quan hệ với chủ hộ (Nếu là chủ hộ nhập '0')", Prompt = "Quan hệ với chủ hộ")]
        [Required(ErrorMessage = "Thiếu thông tin")]
        public string QuanHe { get; set;}

        [Display(Name = "Số hộ khẩu")]
        public string soHoKhau { get; set; }

        [Display(Name = "Nguyên nhân thêm")]
        public string? NguyenNhan { get; set; }

        [Display(Name = "Ngày chuyển đi", Prompt = "Ngày chuyển tới")]
        public DateTime? NgayChuyen { get; set; }

        [Display(Name = "Nơi chuyển tới", Prompt = "Nơi chuyển tới")]
        public string? NoiChuyen { get; set; }

        [Display(Name = "Ghi chú", Prompt = "Ghi chú")]
        public string? GhiChu { get; set; }

        [ForeignKey("soHoKhau")]
        public HoKhau? hoKhau { get; set; }

        [NotMapped]
        public int? DoTuoi { get; set; }

        public string GetStatus() {
            if(NguyenNhan == "Chuyển tới")
            {
                return "Hoạt động";
            }
            return NguyenNhan;
        }

        public string GetColor()
        {
            if (NguyenNhan == "Qua đời" || NguyenNhan == "Chuyển đi")
            {
                return "Red";
            }
            if (NguyenNhan == "Tạm vắng")
            {
                return "Yellow";
            }
            return "inherit";
        }

        public int GetAge()
        {
            int[] ageList = { 0, 4, 6, 11, 15, 18, 65, 999999 };
            int doTuoi = Math.Abs(DateTime.Now.Year - NgaySinh.Year);
            for(int i=0;i <=7;i++)
            {
                if (doTuoi < ageList[i]) return i-1;
            }
            return -1;
        }
    }
}
