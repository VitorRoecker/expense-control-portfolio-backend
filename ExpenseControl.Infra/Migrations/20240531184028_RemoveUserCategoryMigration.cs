using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseControl.Infra.Migrations
{
    public partial class RemoveUserCategoryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesUsers");

            migrationBuilder.DropIndex(
                name: "IX_Category_CategoryUserId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CategoryUserId",
                table: "Category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryUserId",
                table: "Category",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CategoriesUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InclusionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriesUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesUsers_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryUserId",
                table: "Category",
                column: "CategoryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesUsers_CategoryId",
                table: "CategoriesUsers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesUsers_UserId_CategoryId",
                table: "CategoriesUsers",
                columns: new[] { "UserId", "CategoryId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
