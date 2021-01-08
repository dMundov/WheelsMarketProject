using Microsoft.EntityFrameworkCore.Migrations;

namespace WheelsMarket.Data.Migrations
{
    public partial class AdModelAddViewCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Ads",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Ads");
        }
    }
}
