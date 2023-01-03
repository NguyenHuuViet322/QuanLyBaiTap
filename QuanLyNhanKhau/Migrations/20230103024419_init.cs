using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNhanKhau.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoSoVatChat",
                columns: table => new
                {
                    IdItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenCoSoVatChat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soLuong = table.Column<int>(type: "int", nullable: false),
                    hienTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoSoVatChat", x => x.IdItem);
                });

            migrationBuilder.CreateTable(
                name: "HoKhau",
                columns: table => new
                {
                    SoHoKhau = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SoNha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duong = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phuong = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Quan = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoKhau", x => x.SoHoKhau);
                });

            migrationBuilder.CreateTable(
                name: "NhanKhau",
                columns: table => new
                {
                    IdNhanKhau = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BiDanh = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiSinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguyenQuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DanToc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgheNghiep = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NoiLamViec = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CMND = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    NgayCapCMND = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiCapCMND = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NgayDangKi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChiTruoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuanHe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soHoKhau = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    NguyenNhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayChuyen = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoiChuyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanKhau", x => x.IdNhanKhau);
                    table.ForeignKey(
                        name: "FK_NhanKhau_HoKhau_soHoKhau",
                        column: x => x.soHoKhau,
                        principalTable: "HoKhau",
                        principalColumn: "SoHoKhau");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    IdAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMND = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    nhanKhauId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.IdAccount);
                    table.ForeignKey(
                        name: "FK_Account_NhanKhau_nhanKhauId",
                        column: x => x.nhanKhauId,
                        principalTable: "NhanKhau",
                        principalColumn: "IdNhanKhau",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    IdItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoatDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoHoKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayThayDoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoiTuong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.IdItem);
                    table.ForeignKey(
                        name: "FK_History_NhanKhau_DoiTuong",
                        column: x => x.DoiTuong,
                        principalTable: "NhanKhau",
                        principalColumn: "IdNhanKhau");
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    IdRequest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNhanKhau = table.Column<int>(type: "int", nullable: false),
                    requestTime = table.Column<int>(type: "int", nullable: false),
                    requestDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.IdRequest);
                    table.ForeignKey(
                        name: "FK_Request_NhanKhau_IdNhanKhau",
                        column: x => x.IdNhanKhau,
                        principalTable: "NhanKhau",
                        principalColumn: "IdNhanKhau",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_nhanKhauId",
                table: "Account",
                column: "nhanKhauId");

            migrationBuilder.CreateIndex(
                name: "IX_History_DoiTuong",
                table: "History",
                column: "DoiTuong");

            migrationBuilder.CreateIndex(
                name: "IX_NhanKhau_soHoKhau",
                table: "NhanKhau",
                column: "soHoKhau");

            migrationBuilder.CreateIndex(
                name: "IX_Request_IdNhanKhau",
                table: "Request",
                column: "IdNhanKhau");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "CoSoVatChat");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "NhanKhau");

            migrationBuilder.DropTable(
                name: "HoKhau");
        }
    }
}
