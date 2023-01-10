using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoEscola.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Address_Id",
                table: "Student");

            migrationBuilder.DropTable(
                name: "SubjectTeacherSubject");

            migrationBuilder.DropTable(
                name: "TeacherTeacherSubject");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Address");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatAt",
                table: "Teacher",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatAt",
                table: "Teacher",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Teacher",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "StudentsAddressId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StudentsAddressId",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentsAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentsAddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_StudentsAddress_StudentsAddressId",
                        column: x => x.StudentsAddressId,
                        principalTable: "StudentsAddress",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentsAddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_StudentsAddress_StudentsAddressId",
                        column: x => x.StudentsAddressId,
                        principalTable: "StudentsAddress",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentsAddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_StudentsAddress_StudentsAddressId",
                        column: x => x.StudentsAddressId,
                        principalTable: "StudentsAddress",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubject_SubjectsId",
                table: "TeacherSubject",
                column: "SubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubject_TeachersId",
                table: "TeacherSubject",
                column: "TeachersId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentsAddressId",
                table: "Student",
                column: "StudentsAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StudentsAddressId",
                table: "Address",
                column: "StudentsAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_City_StudentsAddressId",
                table: "City",
                column: "StudentsAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_StudentsAddressId",
                table: "Country",
                column: "StudentsAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_State_StudentsAddressId",
                table: "State",
                column: "StudentsAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_StudentsAddress_StudentsAddressId",
                table: "Address",
                column: "StudentsAddressId",
                principalTable: "StudentsAddress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_StudentsAddress_StudentsAddressId",
                table: "Student",
                column: "StudentsAddressId",
                principalTable: "StudentsAddress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubject_Subject_SubjectsId",
                table: "TeacherSubject",
                column: "SubjectsId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubject_Teacher_TeachersId",
                table: "TeacherSubject",
                column: "TeachersId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_StudentsAddress_StudentsAddressId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_StudentsAddress_StudentsAddressId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubject_Subject_SubjectsId",
                table: "TeacherSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubject_Teacher_TeachersId",
                table: "TeacherSubject");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "StudentsAddress");

            migrationBuilder.DropIndex(
                name: "IX_TeacherSubject_SubjectsId",
                table: "TeacherSubject");

            migrationBuilder.DropIndex(
                name: "IX_TeacherSubject_TeachersId",
                table: "TeacherSubject");

            migrationBuilder.DropIndex(
                name: "IX_Student_StudentsAddressId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Address_StudentsAddressId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "StudentsAddressId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentsAddressId",
                table: "Address");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatAt",
                table: "Teacher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatAt",
                table: "Teacher",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Teacher",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Address",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SubjectTeacherSubject",
                columns: table => new
                {
                    SubjectsId = table.Column<int>(type: "int", nullable: false),
                    TeachersSubjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacherSubject", x => new { x.SubjectsId, x.TeachersSubjectsId });
                    table.ForeignKey(
                        name: "FK_SubjectTeacherSubject_Subject_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SubjectTeacherSubject_TeacherSubject_TeachersSubjectsId",
                        column: x => x.TeachersSubjectsId,
                        principalTable: "TeacherSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TeacherTeacherSubject",
                columns: table => new
                {
                    TeachersId = table.Column<int>(type: "int", nullable: false),
                    TeachersSubjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherTeacherSubject", x => new { x.TeachersId, x.TeachersSubjectsId });
                    table.ForeignKey(
                        name: "FK_TeacherTeacherSubject_Teacher_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TeacherTeacherSubject_TeacherSubject_TeachersSubjectsId",
                        column: x => x.TeachersSubjectsId,
                        principalTable: "TeacherSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacherSubject_TeachersSubjectsId",
                table: "SubjectTeacherSubject",
                column: "TeachersSubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTeacherSubject_TeachersSubjectsId",
                table: "TeacherTeacherSubject",
                column: "TeachersSubjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Address_Id",
                table: "Student",
                column: "Id",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
