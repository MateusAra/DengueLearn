using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DengueLearn.Migrations
{
    /// <inheritdoc />
    public partial class updateusermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profile",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Profile",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
