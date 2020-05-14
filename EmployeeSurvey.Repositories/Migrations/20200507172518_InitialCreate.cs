using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeSurvey.Repositories.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    YearsOfExperience = table.Column<int>(nullable: false, defaultValue: 0),
                    CurrentPosition = table.Column<string>(maxLength: 100, nullable: false),
                    SeniorityLevel = table.Column<int>(nullable: false),
                    Hash = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    ProgrammingLanguageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.ProgrammingLanguageId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProgrammingLanguage",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    ProgrammingLanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProgrammingLanguage", x => new { x.EmployeeId, x.ProgrammingLanguageId });
                    table.ForeignKey(
                        name: "FK_EmployeeProgrammingLanguage_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProgrammingLanguage_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "ProgrammingLanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "ProgrammingLanguageId", "Name" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "C++" },
                    { 3, "C" },
                    { 4, "Java" },
                    { 5, "Go" },
                    { 6, "Java Script" },
                    { 7, "Python" },
                    { 8, "PHP" },
                    { 9, "Scala" },
                    { 10, "Ruby" },
                    { 11, "Erlang" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProgrammingLanguage_ProgrammingLanguageId",
                table: "EmployeeProgrammingLanguage",
                column: "ProgrammingLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Hash",
                table: "Employees",
                column: "Hash");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SeniorityLevel",
                table: "Employees",
                column: "SeniorityLevel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProgrammingLanguage");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");
        }
    }
}
