using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Error404NotLost_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolClassId",
                table: "SchoolSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SchoolClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolClass_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolSubjects_SchoolClassId",
                table: "SchoolSubjects",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClass_AuthorId",
                table: "SchoolClass",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolSubjects_SchoolClass_SchoolClassId",
                table: "SchoolSubjects",
                column: "SchoolClassId",
                principalTable: "SchoolClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolSubjects_SchoolClass_SchoolClassId",
                table: "SchoolSubjects");

            migrationBuilder.DropTable(
                name: "SchoolClass");

            migrationBuilder.DropIndex(
                name: "IX_SchoolSubjects_SchoolClassId",
                table: "SchoolSubjects");

            migrationBuilder.DropColumn(
                name: "SchoolClassId",
                table: "SchoolSubjects");
        }
    }
}
