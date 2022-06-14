using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kolokwium.Migrations
{
    public partial class createdtablesvol2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 6, 14, 13, 21, 40, 822, DateTimeKind.Local).AddTicks(5318));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2022, 6, 14, 13, 21, 40, 824, DateTimeKind.Local).AddTicks(9678));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 6, 14, 12, 49, 56, 454, DateTimeKind.Local).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2022, 6, 14, 12, 49, 56, 457, DateTimeKind.Local).AddTicks(4055));
        }
    }
}
