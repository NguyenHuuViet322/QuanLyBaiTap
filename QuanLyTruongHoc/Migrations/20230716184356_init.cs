using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyTruongHoc.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Khoi = table.Column<int>(type: "int", nullable: false),
                    IdGiaoVien = table.Column<int>(type: "int", nullable: false),
                    namVaoTruong = table.Column<int>(type: "int", nullable: false),
                    namRaTruong = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenCoSoVatChat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soLuong = table.Column<int>(type: "int", nullable: false),
                    hienTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceBorrow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDevice = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdDoiTuong = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ngayMuon = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceBorrow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "giaoVienMonHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGiaoVien = table.Column<int>(type: "int", nullable: false),
                    IdMonHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_giaoVienMonHocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradeProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKiThi = table.Column<int>(type: "int", nullable: false),
                    IdHocSinh = table.Column<int>(type: "int", nullable: false),
                    Diem = table.Column<float>(type: "real", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HocBa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHocSinh = table.Column<int>(type: "int", nullable: false),
                    trangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocBa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KiThi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    heSo = table.Column<float>(type: "real", nullable: false),
                    khoi = table.Column<int>(type: "int", nullable: false),
                    namHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMonHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KiThi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KiThiLopHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKiThi = table.Column<int>(type: "int", nullable: false),
                    IdLopHoc = table.Column<int>(type: "int", nullable: false),
                    IdGiaoVien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KiThiLopHoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGiaoVien = table.Column<int>(type: "int", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLop = table.Column<int>(type: "int", nullable: false),
                    hoTenCha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hoTenMe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngheNghiepCha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngheNghiepMe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nienKhoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gioiTinh = table.Column<int>(type: "int", nullable: false),
                    noiSinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    danToc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diaChiThuongTru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngheNghiep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMND = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bangCap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chuyenMon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phanQuyen = table.Column<int>(type: "int", nullable: false),
                    luong = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gioiTinh = table.Column<int>(type: "int", nullable: false),
                    noiSinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    danToc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diaChiThuongTru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngheNghiep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMND = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongBao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGiaoVien = table.Column<int>(type: "int", nullable: false),
                    loaiThongBao = table.Column<int>(type: "int", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongBaoLopHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdThongBao = table.Column<int>(type: "int", nullable: false),
                    IdLopHoc = table.Column<int>(type: "int", nullable: false),
                    IdHocSinh = table.Column<int>(type: "int", nullable: false),
                    IdGiaoVienDt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBaoLopHoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TKB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KiHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhoiHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TKB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TKBItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTKB = table.Column<int>(type: "int", nullable: false),
                    IdGiaoVien = table.Column<int>(type: "int", nullable: false),
                    IdMonHoc = table.Column<int>(type: "int", nullable: false),
                    day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tietHoc = table.Column<int>(type: "int", nullable: false),
                    IdLop = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TKBItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoiTuong = table.Column<int>(type: "int", nullable: false),
                    typeTransaction = table.Column<int>(type: "int", nullable: false),
                    fee = table.Column<float>(type: "real", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPayment = table.Column<int>(type: "int", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TimeCreate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionUser", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "DeviceBorrow");

            migrationBuilder.DropTable(
                name: "giaoVienMonHocs");

            migrationBuilder.DropTable(
                name: "GradeProfile");

            migrationBuilder.DropTable(
                name: "HocBa");

            migrationBuilder.DropTable(
                name: "KiThi");

            migrationBuilder.DropTable(
                name: "KiThiLopHoc");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "StudentInfo");

            migrationBuilder.DropTable(
                name: "TeacherInfo");

            migrationBuilder.DropTable(
                name: "ThongBao");

            migrationBuilder.DropTable(
                name: "ThongBaoLopHoc");

            migrationBuilder.DropTable(
                name: "TKB");

            migrationBuilder.DropTable(
                name: "TKBItem");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "TransactionUser");
        }
    }
}
