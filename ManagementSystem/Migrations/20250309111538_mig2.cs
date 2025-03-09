using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "UserType" },
                values: new object[] { new byte[] { 185, 56, 221, 43, 126, 88, 221, 75, 125, 165, 58, 195, 116, 141, 96, 199, 162, 96, 164, 157, 4, 210, 28, 116, 180, 235, 169, 161, 206, 51, 244, 157, 211, 172, 118, 113, 198, 235, 18, 240, 145, 195, 89, 241, 125, 18, 237, 234, 201, 223, 105, 113, 71, 153, 58, 25, 81, 129, 212, 54, 159, 173, 14, 173 }, new byte[] { 222, 219, 100, 21, 14, 171, 170, 3, 164, 20, 44, 170, 16, 250, 250, 135, 175, 19, 196, 112, 19, 247, 66, 56, 206, 220, 210, 228, 249, 118, 155, 93 }, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt", "UserType" },
                values: new object[] { new byte[] { 185, 56, 221, 43, 126, 88, 221, 75, 125, 165, 58, 195, 116, 141, 96, 199, 162, 96, 164, 157, 4, 210, 28, 116, 180, 235, 169, 161, 206, 51, 244, 157, 211, 172, 118, 113, 198, 235, 18, 240, 145, 195, 89, 241, 125, 18, 237, 234, 201, 223, 105, 113, 71, 153, 58, 25, 81, 129, 212, 54, 159, 173, 14, 173 }, new byte[] { 222, 219, 100, 21, 14, 171, 170, 3, 164, 20, 44, 170, 16, 250, 250, 135, 175, 19, 196, 112, 19, 247, 66, 56, 206, 220, 210, 228, 249, 118, 155, 93 }, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "UserType" },
                values: new object[] { "123", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "UserType" },
                values: new object[] { "123", 0 });
        }
    }
}
