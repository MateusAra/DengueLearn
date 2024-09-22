using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DengueLearn.Migrations
{
    /// <inheritdoc />
    public partial class removeprops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultQuiz_User_UserId",
                table: "ResultQuiz");

            migrationBuilder.DropIndex(
                name: "IX_ResultQuiz_UserId",
                table: "ResultQuiz");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ResultQuiz_UserId",
                table: "ResultQuiz",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultQuiz_User_UserId",
                table: "ResultQuiz",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
