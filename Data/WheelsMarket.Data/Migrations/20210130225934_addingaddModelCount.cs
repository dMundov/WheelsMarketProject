using Microsoft.EntityFrameworkCore.Migrations;

namespace WheelsMarket.Data.Migrations
{
    public partial class addingaddModelCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Ads",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Ads");
        }
    }
}
