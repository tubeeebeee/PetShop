using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShop.Migrations
{
    public partial class addCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Pid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkFaceBook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zalo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    GoogleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Pid);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Pid", "ActivationCode", "Address", "AvatarUrl", "CreatedDate", "Day", "Deleted", "DeletedDate", "District", "Email", "Enabled", "FacebookId", "FirstName", "GoogleId", "LastName", "LinkFaceBook", "Month", "Password", "PhoneNumber", "Province", "UpdatedDate", "Ward", "Year", "Zalo" },
                values: new object[] { 1, "", "124, N11", "", new DateTime(2022, 12, 16, 11, 31, 42, 999, DateTimeKind.Local).AddTicks(210), 27, false, null, "", "hoangminhtubeee@gmail.com", true, "", "Hoang", "", "Tu", "", 10, "$2a$11$v2iqhV1GVGuv7GE32fjhfOkUerlSCRnt/reTj6zxNKHTQx8McHKCO", "0976743321", "", null, "", 1997, "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
