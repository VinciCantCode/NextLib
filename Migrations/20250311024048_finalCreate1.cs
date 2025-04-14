using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestLibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class finalCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryBranches",
                table: "LibraryBranches");

            migrationBuilder.DropColumn(
                name: "LibraryBranchId",
                table: "LibraryBranches");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "LibraryBranches");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "LibraryBranches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryBranches",
                table: "LibraryBranches",
                column: "LibraryBranchName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryBranches",
                table: "LibraryBranches");

            migrationBuilder.AddColumn<int>(
                name: "LibraryBranchId",
                table: "LibraryBranches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "LibraryBranches",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "LibraryBranches",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryBranches",
                table: "LibraryBranches",
                column: "LibraryBranchId");
        }
    }
}
