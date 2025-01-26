using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movierecommend.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "rating",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "rating",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "rating");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "rating",
                newName: "Name");
        }
    }
}
