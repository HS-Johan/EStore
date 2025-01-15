using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class LookUp_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "LookUp");

            migrationBuilder.DropColumn(
                name: "CopyRight",
                table: "LookUp");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "LookUp");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "LookUp");

            migrationBuilder.DropColumn(
                name: "Social",
                table: "LookUp");

            migrationBuilder.DropColumn(
                name: "SupportEmail",
                table: "LookUp");

            migrationBuilder.RenameColumn(
                name: "TempBy",
                table: "LookUp",
                newName: "LookUpIcon");

            migrationBuilder.RenameColumn(
                name: "SupportPhone",
                table: "LookUp",
                newName: "LookUpData");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "LookUp",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LookUpType",
                table: "LookUp",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "LookUp");

            migrationBuilder.DropColumn(
                name: "LookUpType",
                table: "LookUp");

            migrationBuilder.RenameColumn(
                name: "LookUpIcon",
                table: "LookUp",
                newName: "TempBy");

            migrationBuilder.RenameColumn(
                name: "LookUpData",
                table: "LookUp",
                newName: "SupportPhone");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "LookUp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopyRight",
                table: "LookUp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "LookUp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "LookUp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Social",
                table: "LookUp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupportEmail",
                table: "LookUp",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
