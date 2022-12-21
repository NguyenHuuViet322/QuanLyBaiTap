using Microsoft.AspNetCore.Authentication.Cookies;

namespace QuanLyNhanKhau.Models
{
    public class Key
    {
        public static List<string> ListDuong = new List<string>(){"Đà nẵng", "Chu Văn An", "Văn Cao",
                                                                    "Lê Lai", "Lê Lợi", "Đổng Quốc Bình",
                                                                    "Bùi Thị Từ Nhiên"};

        public static List<string> ListPhuong = new List<string>() { "Vạn Mỹ", "Máy Chai", "Máy Tơ" };

        public static List<string> ListQuan = new List<string>() { "Ngô Quyền", "Hải An", "An Lão",
                                                                    "Hồng Bàng"};

        public static List<string> ListTP = new List<string>() { "Hải Phòng", "Hà Nội", "Thái Bình",
                                                                    "Huế"};
        public static List<string> ListGioiTinh = new List<string>() { "Nam", "Nữ", "Gay"};
    }
}
