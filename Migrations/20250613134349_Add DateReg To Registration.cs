using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTickets.Migrations
{
    /// <inheritdoc />
    public partial class AddDateRegToRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateReg",
                table: "Registration",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateReg",
                table: "Registration");
        }
    }
}
