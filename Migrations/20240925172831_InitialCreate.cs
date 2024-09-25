using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace notice.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Notices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: true),
                    DateOfNotice = table.Column<DateOnly>(type: "date", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    Locality = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    Dom = table.Column<string>(type: "text", nullable: true),
                    Kv = table.Column<string>(type: "text", nullable: true),
                    TemporaryAddress = table.Column<string>(type: "text", nullable: true),
                    Resident = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    SocialGroup = table.Column<string>(type: "text", nullable: true),
                    Work = table.Column<string>(type: "text", nullable: true),
                    Diagnosis = table.Column<string>(type: "text", nullable: true),
                    DiagnosisDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Reminfection = table.Column<bool>(type: "boolean", nullable: false),
                    Confirmation = table.Column<string>(type: "text", nullable: true),
                    Causative = table.Column<string>(type: "text", nullable: true),
                    TransmissionPath = table.Column<string>(type: "text", nullable: true),
                    PlaceOfDetection = table.Column<string>(type: "text", nullable: true),
                    Additional = table.Column<string>(type: "text", nullable: true),
                    Circumstances = table.Column<string>(type: "text", nullable: true),
                    PregnancyDuration = table.Column<string>(type: "text", nullable: true),
                    Doctor = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notices_Users_Username",
                        column: x => x.Username,
                        principalTable: "Users",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notices_Username",
                table: "Notices",
                column: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notices");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
