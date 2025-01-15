using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class LookUp_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookUp",
                columns: table => new
                {
                    LookUpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupportEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupportPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyRight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Social = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp", x => x.LookUpId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LookUp");
        }
    }
}
