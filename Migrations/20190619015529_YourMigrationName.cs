using Microsoft.EntityFrameworkCore.Migrations;

namespace wedding.Migrations
{
    public partial class YourMigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Weddings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssociateID",
                table: "Weddings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Weddings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_UserID",
                table: "Weddings",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Users_UserID",
                table: "Weddings",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Users_UserID",
                table: "Weddings");

            migrationBuilder.DropIndex(
                name: "IX_Weddings_UserID",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "AssociateID",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Weddings");
        }
    }
}
