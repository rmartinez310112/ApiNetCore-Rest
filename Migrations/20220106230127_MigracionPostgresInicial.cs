using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiTrueHome.Migrations
{
    public partial class MigracionPostgresInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    property_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    create_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    disabled_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    propertyGuid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.property_id);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    activity_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    schedule = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<string>(type: "text", nullable: true),
                    property_id = table.Column<int>(type: "integer", nullable: false),
                    property_id1 = table.Column<int>(type: "integer", nullable: true),
                    activityGuid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.activity_id);
                    table.ForeignKey(
                        name: "FK_Activity_Property_property_id1",
                        column: x => x.property_id1,
                        principalTable: "Property",
                        principalColumn: "property_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    survey_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    answer = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    activity_id = table.Column<int>(type: "integer", nullable: false),
                    activity_id1 = table.Column<int>(type: "integer", nullable: true),
                    surveyGuid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.survey_id);
                    table.ForeignKey(
                        name: "FK_Survey_Activity_activity_id1",
                        column: x => x.activity_id1,
                        principalTable: "Activity",
                        principalColumn: "activity_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_property_id1",
                table: "Activity",
                column: "property_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_activity_id1",
                table: "Survey",
                column: "activity_id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Property");
        }
    }
}
