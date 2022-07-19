using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SepetSistemi.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_sepet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durumu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_sepet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "altkategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_altkategori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_altkategori_kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "urun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kampanya = table.Column<bool>(type: "bit", nullable: false),
                    KampanyaOrani = table.Column<int>(type: "int", nullable: false),
                    AltKategoriId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urun_altkategori_AltKategoriId",
                        column: x => x.AltKategoriId,
                        principalTable: "altkategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_sepet_urun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SepetId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_sepet_urun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_sepet_urun_tbl_sepet_SepetId",
                        column: x => x.SepetId,
                        principalTable: "tbl_sepet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_sepet_urun_urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "urun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_altkategori_KategoriId",
                table: "altkategori",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_sepet_urun_SepetId",
                table: "tbl_sepet_urun",
                column: "SepetId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_sepet_urun_UrunId",
                table: "tbl_sepet_urun",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_urun_AltKategoriId",
                table: "urun",
                column: "AltKategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_sepet_urun");

            migrationBuilder.DropTable(
                name: "tbl_sepet");

            migrationBuilder.DropTable(
                name: "urun");

            migrationBuilder.DropTable(
                name: "altkategori");

            migrationBuilder.DropTable(
                name: "kategori");
        }
    }
}
