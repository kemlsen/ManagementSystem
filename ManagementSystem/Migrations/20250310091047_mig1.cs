using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UserName", "UserType" },
                values: new object[,]
                {
                    { 1, "Dincer", "Teknoloji", new byte[] { 11, 54, 62, 240, 159, 165, 184, 150, 168, 114, 83, 20, 142, 97, 71, 182, 100, 171, 169, 16, 205, 16, 7, 251, 84, 237, 243, 76, 117, 235, 46, 226, 17, 88, 82, 212, 112, 64, 155, 240, 63, 69, 146, 217, 32, 194, 35, 2, 119, 182, 34, 135, 143, 33, 10, 184, 24, 62, 131, 182, 235, 177, 81, 99 }, new byte[] { 132, 225, 102, 92, 223, 144, 89, 34, 201, 70, 254, 48, 247, 32, 115, 109, 186, 132, 232, 94, 124, 40, 202, 53, 197, 146, 231, 211, 126, 72, 179, 96, 30, 85, 82, 7, 42, 213, 204, 142, 121, 132, 24, 42, 127, 152, 131, 128, 53, 168, 88, 153, 13, 116, 182, 8, 69, 249, 181, 197, 197, 223, 187, 194, 189, 122, 178, 12, 124, 250, 166, 210, 204, 54, 100, 124, 39, 59, 145, 189, 119, 233, 8, 93, 113, 189, 161, 67, 185, 203, 57, 29, 136, 91, 197, 234, 14, 199, 17, 192, 243, 157, 71, 186, 238, 174, 237, 63, 85, 78, 62, 67, 177, 249, 107, 12, 121, 186, 56, 203, 177, 166, 230, 1, 163, 75, 223, 80 }, "admindincer", 2 },
                    { 2, "Kemal", "Sen", new byte[] { 11, 54, 62, 240, 159, 165, 184, 150, 168, 114, 83, 20, 142, 97, 71, 182, 100, 171, 169, 16, 205, 16, 7, 251, 84, 237, 243, 76, 117, 235, 46, 226, 17, 88, 82, 212, 112, 64, 155, 240, 63, 69, 146, 217, 32, 194, 35, 2, 119, 182, 34, 135, 143, 33, 10, 184, 24, 62, 131, 182, 235, 177, 81, 99 }, new byte[] { 132, 225, 102, 92, 223, 144, 89, 34, 201, 70, 254, 48, 247, 32, 115, 109, 186, 132, 232, 94, 124, 40, 202, 53, 197, 146, 231, 211, 126, 72, 179, 96, 30, 85, 82, 7, 42, 213, 204, 142, 121, 132, 24, 42, 127, 152, 131, 128, 53, 168, 88, 153, 13, 116, 182, 8, 69, 249, 181, 197, 197, 223, 187, 194, 189, 122, 178, 12, 124, 250, 166, 210, 204, 54, 100, 124, 39, 59, 145, 189, 119, 233, 8, 93, 113, 189, 161, 67, 185, 203, 57, 29, 136, 91, 197, 234, 14, 199, 17, 192, 243, 157, 71, 186, 238, 174, 237, 63, 85, 78, 62, 67, 177, 249, 107, 12, 121, 186, 56, 203, 177, 166, 230, 1, 163, 75, 223, 80 }, "userkemal", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
