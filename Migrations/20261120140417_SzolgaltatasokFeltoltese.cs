using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Idopontfoglalo_Rendszer.Migrations
{
    /// <inheritdoc />
    public partial class SzolgaltatasokFeltoltese : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Szolgaltatas",
                columns: new[] { "ID", "Nev" },
                values: new object[,]
                {
                    { 1, "Várandós tanácsadás" },
                    { 2, "Csecsemő védőnői tanácsadás (0-1 év)" },
                    { 3, "Gyerek tanácsadás (1-6 év)" },
                    { 4, "Védőnői fogadóóra" },
                    { 5, "Szülés felkészítő" },
                    { 6, "Méhnyakrák szűrés" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Szolgaltatas",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Szolgaltatas",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Szolgaltatas",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Szolgaltatas",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Szolgaltatas",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Szolgaltatas",
                keyColumn: "ID",
                keyValue: 6);
        }
    }
}
