using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoEscola.Data.Migrations
{
    public partial class Update_ForeignKey_StudensAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_StudentsAddress_StudentsAddressId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_City_StudentsAddress_StudentsAddressId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Country_StudentsAddress_StudentsAddressId",
                table: "Country");

            migrationBuilder.DropForeignKey(
                name: "FK_State_StudentsAddress_StudentsAddressId",
                table: "State");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_StudentsAddress_StudentsAddressId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_StudentsAddressId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_State_StudentsAddressId",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_Country_StudentsAddressId",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_City_StudentsAddressId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_Address_StudentsAddressId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "StudentsAddressId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentsAddressId",
                table: "State");

            migrationBuilder.DropColumn(
                name: "StudentsAddressId",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "StudentsAddressId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "StudentsAddressId",
                table: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "State",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Country",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "City",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_StudentsAddress_Id",
                table: "Address",
                column: "Id",
                principalTable: "StudentsAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_City_StudentsAddress_Id",
                table: "City",
                column: "Id",
                principalTable: "StudentsAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Country_StudentsAddress_Id",
                table: "Country",
                column: "Id",
                principalTable: "StudentsAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_State_StudentsAddress_Id",
                table: "State",
                column: "Id",
                principalTable: "StudentsAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_StudentsAddress_Id",
                table: "Student",
                column: "Id",
                principalTable: "StudentsAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_StudentsAddress_Id",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_City_StudentsAddress_Id",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Country_StudentsAddress_Id",
                table: "Country");

            migrationBuilder.DropForeignKey(
                name: "FK_State_StudentsAddress_Id",
                table: "State");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_StudentsAddress_Id",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "StudentsAddressId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "State",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StudentsAddressId",
                table: "State",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Country",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StudentsAddressId",
                table: "Country",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "City",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StudentsAddressId",
                table: "City",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentsAddressId",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentsAddressId",
                table: "Student",
                column: "StudentsAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_State_StudentsAddressId",
                table: "State",
                column: "StudentsAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_StudentsAddressId",
                table: "Country",
                column: "StudentsAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_City_StudentsAddressId",
                table: "City",
                column: "StudentsAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StudentsAddressId",
                table: "Address",
                column: "StudentsAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_StudentsAddress_StudentsAddressId",
                table: "Address",
                column: "StudentsAddressId",
                principalTable: "StudentsAddress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_City_StudentsAddress_StudentsAddressId",
                table: "City",
                column: "StudentsAddressId",
                principalTable: "StudentsAddress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Country_StudentsAddress_StudentsAddressId",
                table: "Country",
                column: "StudentsAddressId",
                principalTable: "StudentsAddress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_State_StudentsAddress_StudentsAddressId",
                table: "State",
                column: "StudentsAddressId",
                principalTable: "StudentsAddress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_StudentsAddress_StudentsAddressId",
                table: "Student",
                column: "StudentsAddressId",
                principalTable: "StudentsAddress",
                principalColumn: "Id");
        }
    }
}
