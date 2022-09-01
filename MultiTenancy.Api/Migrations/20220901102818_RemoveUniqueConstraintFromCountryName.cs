using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiTenancy.Api.Migrations
{
    public partial class RemoveUniqueConstraintFromCountryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Countries_Name",
                table: "Countries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);
        }
    }
}
