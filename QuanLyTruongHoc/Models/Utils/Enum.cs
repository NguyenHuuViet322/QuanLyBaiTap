using System.ComponentModel;

namespace QuanLyTruongHoc.Models.Utils
{
    public enum EnumGender
    {
        [Description("Nam")]
        Male = 1,
        [Description("Nữ")]
        Female = 2
    }

    public enum LoaiThongBao
    {
        [Description("Thông báo tới lớp học")]
        Lop = 1,
        [Description("Thông báo tới học sinh")]
        HocSinh = 2,
        [Description("Thông báo tới giáo viên")]
        GiaoVien = 3
    }

    public enum Role
    {
        [Description("Học sinh")]
        Student = 1,
        [Description("Giáo viên")]
        Teacher = 2,
        [Description("Giáo vụ")]
        AssistantPrincipal = 3,
        [Description("Ban giám hiệu")]
        Principal = 4,
        [Description("Full quyền")]
        Admin = 5,
    }

    public enum HSGV
    {
        [Description("Học sinh")]
        HocSinh = 1,
        [Description("Giáo viên")]
        GiaoVien = 2,
    }

    public enum DoiTuong
    {
        [Description("Khối 10")]
        Khoi10 = 1,
        [Description("Khối 11")]
        Khoi11 = 2,
        [Description("Khối 12")]
        Khoi12 = 3,
        [Description("học sinh toàn trường")]
        ToanTruong = 4,
        [Description("Toàn bộ giáo viên")]
        GiaoVien = 5,
        [Description("Toàn trường")]
        TatCa = 6
    }

    public enum TrangThaiMuon
    {
        [Description("Đang mượn")]
        DangMuon = 1,
        [Description("Đã trả")]
        DaTra = 2
    }
    public static class Constance {
        public static string usernameAdmin = "admin";
        public static string passwordAdmin = "123";
    }
}
