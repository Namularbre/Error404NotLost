using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Error404NotLost_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialEntitiesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClass_AspNetUsers_AuthorId",
                table: "SchoolClass");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolSubjects_SchoolClass_SchoolClassId",
                table: "SchoolSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolClass",
                table: "SchoolClass");

            migrationBuilder.RenameTable(
                name: "SchoolClass",
                newName: "SchoolClasses");

            migrationBuilder.RenameIndex(
                name: "IX_SchoolClass_AuthorId",
                table: "SchoolClasses",
                newName: "IX_SchoolClasses_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolClasses",
                table: "SchoolClasses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tutorings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolClassId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutorings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tutorings_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tutorings_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tutorings_SchoolClasses_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tutorings_AuthorId",
                table: "Tutorings",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorings_LocationId",
                table: "Tutorings",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorings_SchoolClassId",
                table: "Tutorings",
                column: "SchoolClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_AspNetUsers_AuthorId",
                table: "SchoolClasses",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolSubjects_SchoolClasses_SchoolClassId",
                table: "SchoolSubjects",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_AspNetUsers_AuthorId",
                table: "SchoolClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolSubjects_SchoolClasses_SchoolClassId",
                table: "SchoolSubjects");

            migrationBuilder.DropTable(
                name: "Tutorings");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolClasses",
                table: "SchoolClasses");

            migrationBuilder.RenameTable(
                name: "SchoolClasses",
                newName: "SchoolClass");

            migrationBuilder.RenameIndex(
                name: "IX_SchoolClasses_AuthorId",
                table: "SchoolClass",
                newName: "IX_SchoolClass_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolClass",
                table: "SchoolClass",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClass_AspNetUsers_AuthorId",
                table: "SchoolClass",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolSubjects_SchoolClass_SchoolClassId",
                table: "SchoolSubjects",
                column: "SchoolClassId",
                principalTable: "SchoolClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
