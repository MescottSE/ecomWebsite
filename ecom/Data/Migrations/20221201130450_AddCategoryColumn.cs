using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecom.Data.Migrations
{
    public partial class AddCategoryColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "Product");
        }
    }
}
