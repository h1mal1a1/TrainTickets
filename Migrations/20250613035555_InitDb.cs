using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TrainTickets.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingStatuses",
                columns: table => new
                {
                    IdBookingStatus = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookingName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatuses", x => x.IdBookingStatus);
                });

            migrationBuilder.CreateTable(
                name: "ClassTypes",
                columns: table => new
                {
                    IdClassType = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTypes", x => x.IdClassType);
                });

            migrationBuilder.CreateTable(
                name: "LastNames",
                columns: table => new
                {
                    IdLastName = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastNames", x => x.IdLastName);
                });

            migrationBuilder.CreateTable(
                name: "Names",
                columns: table => new
                {
                    IdName = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Names", x => x.IdName);
                });

            migrationBuilder.CreateTable(
                name: "Patronymics",
                columns: table => new
                {
                    IdPatronymic = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patronymics", x => x.IdPatronymic);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    IdStation = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StationName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.IdStation);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    TicketId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArrivalTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CarriageNumber = table.Column<int>(type: "integer", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdArrivalStation = table.Column<int>(type: "integer", nullable: false),
                    IdBookingStatus = table.Column<int>(type: "integer", nullable: false),
                    IdClassType = table.Column<int>(type: "integer", nullable: false),
                    IdDepartureStation = table.Column<int>(type: "integer", nullable: false),
                    IdLastName = table.Column<int>(type: "integer", nullable: false),
                    IdName = table.Column<int>(type: "integer", nullable: false),
                    IdPatronymic = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    SeatNumber = table.Column<int>(type: "integer", nullable: false),
                    TrainNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Registration_BookingStatuses_IdBookingStatus",
                        column: x => x.IdBookingStatus,
                        principalTable: "BookingStatuses",
                        principalColumn: "IdBookingStatus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_ClassTypes_IdClassType",
                        column: x => x.IdClassType,
                        principalTable: "ClassTypes",
                        principalColumn: "IdClassType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_LastNames_IdLastName",
                        column: x => x.IdLastName,
                        principalTable: "LastNames",
                        principalColumn: "IdLastName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Names_IdName",
                        column: x => x.IdName,
                        principalTable: "Names",
                        principalColumn: "IdName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Patronymics_IdPatronymic",
                        column: x => x.IdPatronymic,
                        principalTable: "Patronymics",
                        principalColumn: "IdPatronymic",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Stations_IdArrivalStation",
                        column: x => x.IdArrivalStation,
                        principalTable: "Stations",
                        principalColumn: "IdStation",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Stations_IdDepartureStation",
                        column: x => x.IdDepartureStation,
                        principalTable: "Stations",
                        principalColumn: "IdStation",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingStatuses_BookingName",
                table: "BookingStatuses",
                column: "BookingName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingStatuses_IdBookingStatus",
                table: "BookingStatuses",
                column: "IdBookingStatus");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTypes_IdClassType",
                table: "ClassTypes",
                column: "IdClassType");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTypes_TypeName",
                table: "ClassTypes",
                column: "TypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LastNames_IdLastName",
                table: "LastNames",
                column: "IdLastName");

            migrationBuilder.CreateIndex(
                name: "IX_LastNames_LastName",
                table: "LastNames",
                column: "LastName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Names_IdName",
                table: "Names",
                column: "IdName");

            migrationBuilder.CreateIndex(
                name: "IX_Names_Name",
                table: "Names",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patronymics_IdPatronymic",
                table: "Patronymics",
                column: "IdPatronymic");

            migrationBuilder.CreateIndex(
                name: "IX_Patronymics_Name",
                table: "Patronymics",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registration_IdArrivalStation",
                table: "Registration",
                column: "IdArrivalStation");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_IdBookingStatus",
                table: "Registration",
                column: "IdBookingStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_IdClassType",
                table: "Registration",
                column: "IdClassType");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_IdDepartureStation",
                table: "Registration",
                column: "IdDepartureStation");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_IdLastName",
                table: "Registration",
                column: "IdLastName");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_IdName",
                table: "Registration",
                column: "IdName");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_IdPatronymic",
                table: "Registration",
                column: "IdPatronymic");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_IdStation",
                table: "Stations",
                column: "IdStation");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_StationName",
                table: "Stations",
                column: "StationName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "BookingStatuses");

            migrationBuilder.DropTable(
                name: "ClassTypes");

            migrationBuilder.DropTable(
                name: "LastNames");

            migrationBuilder.DropTable(
                name: "Names");

            migrationBuilder.DropTable(
                name: "Patronymics");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
