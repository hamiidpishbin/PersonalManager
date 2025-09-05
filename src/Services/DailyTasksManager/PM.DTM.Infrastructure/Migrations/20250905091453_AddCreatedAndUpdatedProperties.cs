using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PM.DTM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedAndUpdatedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "WorkItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "WorkItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Sprint",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Sprint",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "WorkItems");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "WorkItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Sprint");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Sprint");
        }
    }
}
