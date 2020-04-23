using Microsoft.EntityFrameworkCore.Migrations;

namespace DSSettings.Migrations
{
    public partial class DSSettingsModelsRepositoryContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SettingsCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingsCategoryData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsCategoryData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingsCategoryData_SettingsCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SettingsCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SettingsCategoryData_CategoryId",
                table: "SettingsCategoryData",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingsCategoryData");

            migrationBuilder.DropTable(
                name: "SettingsCategory");
        }
    }
}
