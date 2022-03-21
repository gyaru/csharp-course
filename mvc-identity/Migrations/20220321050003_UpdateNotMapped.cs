using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc_identity.Migrations
{
    public partial class UpdateNotMapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e1792d3-47c8-4949-9a92-7f8da552b402");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "fb3687ed-4040-4590-814d-b6129ea76f50", "073e08b0-0437-4354-838a-c3a5bdd6e07b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "073e08b0-0437-4354-838a-c3a5bdd6e07b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb3687ed-4040-4590-814d-b6129ea76f50");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b909a4a-22c7-4b19-aa69-ed4a6d15cd9b", "a5f392aa-3b43-4eda-a3f8-31aa09737c8a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f016a198-3500-42e3-96d9-d8cb1693d784", "2aba3540-53db-4d72-b98d-59215018f11b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "145d855d-9628-4893-ad15-142ba3df373a", 0, "1955-02-24", "a86484a0-113e-445d-8ff6-b53d28258461", "steve@apple.com", false, "Steve", "Jobs", false, null, "STEVE@APPLE.COM", "steve@apple.com", "AQAAAAEAACcQAAAAELNsdjlYTXJ4a2L/JzciK9Mk2HsZX5x4KBIKrY11TMiBLCIK6ibvYShP4XMMFy7fDQ==", null, false, "acc9b399-b57d-4025-b2d4-5ea47868897c", false, "steve@apple.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "145d855d-9628-4893-ad15-142ba3df373a", "0b909a4a-22c7-4b19-aa69-ed4a6d15cd9b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f016a198-3500-42e3-96d9-d8cb1693d784");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "145d855d-9628-4893-ad15-142ba3df373a", "0b909a4a-22c7-4b19-aa69-ed4a6d15cd9b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b909a4a-22c7-4b19-aa69-ed4a6d15cd9b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "145d855d-9628-4893-ad15-142ba3df373a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "073e08b0-0437-4354-838a-c3a5bdd6e07b", "7fd17868-1b32-4b0e-8b1e-793e8b2a8114", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8e1792d3-47c8-4949-9a92-7f8da552b402", "726207a5-241b-4c39-92e9-82c21c45a1e9", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fb3687ed-4040-4590-814d-b6129ea76f50", 0, "1955-02-24", "def51090-b62b-4e3a-b67f-8153e56eb70c", "steve@apple.com", false, "Steve", "Jobs", false, null, "STEVE@APPLE.COM", "steve@apple.com", "AQAAAAEAACcQAAAAEBsJPiELbJ1UNOhkFF6orzzdpit3U7T4awqirMAnVqQgMM/jxcv+gjyJjs63clfGlQ==", null, false, "946be414-dc2c-4361-822e-2afc1bb640c2", false, "steve@apple.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "fb3687ed-4040-4590-814d-b6129ea76f50", "073e08b0-0437-4354-838a-c3a5bdd6e07b" });
        }
    }
}
