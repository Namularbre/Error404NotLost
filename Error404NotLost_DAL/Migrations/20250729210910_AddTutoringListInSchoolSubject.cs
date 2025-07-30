using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Error404NotLost_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTutoringListInSchoolSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tutorings_SchoolClasses_SchoolClassId",
                table: "Tutorings");

            migrationBuilder.RenameColumn(
                name: "SchoolClassId",
                table: "Tutorings",
                newName: "SchoolSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Tutorings_SchoolClassId",
                table: "Tutorings",
                newName: "IX_Tutorings_SchoolSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tutorings_SchoolSubjects_SchoolSubjectId",
                table: "Tutorings",
                column: "SchoolSubjectId",
                principalTable: "SchoolSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tutorings_SchoolSubjects_SchoolSubjectId",
                table: "Tutorings");

            migrationBuilder.RenameColumn(
                name: "SchoolSubjectId",
                table: "Tutorings",
                newName: "SchoolClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Tutorings_SchoolSubjectId",
                table: "Tutorings",
                newName: "IX_Tutorings_SchoolClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tutorings_SchoolClasses_SchoolClassId",
                table: "Tutorings",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
