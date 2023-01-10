using Microsoft.AspNetCore.Authentication.Cookies;
using System.ComponentModel;
using System.Reflection;

namespace QuanLyNhanKhau.Models
{
    public class Key
    {
        public static List<string> ListDuong = new List<string>(){"Đà Nẵng", "Chu Văn An", "Văn Cao",
                                                                    "Lê Lai", "Lê Lợi", "Đổng Quốc Bình",
                                                                    "Bùi Thị Từ Nhiên"};

        public static List<string> ListPhuong = new List<string>() { "Vạn Mỹ", "Máy Chai", "Máy Tơ" };

        public static List<string> ListQuan = new List<string>() { "Ngô Quyền", "Hải An", "An Lão",
                                                                    "Hồng Bàng"};

        public static List<string> ListTP = new List<string>() { "Hải Phòng", "Hà Nội", "Thái Bình",
                                                                    "Huế"};
        public static List<string> ListGioiTinh = new List<string>() { "Nam", "Nữ", "Gay"} ;

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }

    public enum Role
    {
        [Description("Công dân")]
        Dan = 0,
        [Description("Quản lý")]
        CanBo = 1,
        [Description("Cán bộ")]
        NhaVH = 2,
        [Description("Admin")]
        Admin = 3
    }

    public enum DoTuoi
    {
        [Description("Mầm non")]
        MamNon = 0,
        [Description("Mẫu giáo")]
        MauGiao = 1,
        [Description("Cấp 1")]
        Cap1 = 2,
        [Description("Cấp 2")]
        Cap2 = 3,
        [Description("Cấp 3")]
        Cap3 = 4,
        [Description("Lao động")]
        LaoDong = 5,
        [Description("Nghỉ hưu")]
        NghiHuu = 6
    }
}
