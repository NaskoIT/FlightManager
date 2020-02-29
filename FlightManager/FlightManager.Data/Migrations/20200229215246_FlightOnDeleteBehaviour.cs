using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManager.Data.Migrations
{
    public partial class FlightOnDeleteBehaviour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Locations_DestinationId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Locations_OriginId",
                table: "Flights");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Locations_DestinationId",
                table: "Flights",
                column: "DestinationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Locations_OriginId",
                table: "Flights",
                column: "OriginId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Locations_DestinationId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Locations_OriginId",
                table: "Flights");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Locations_DestinationId",
                table: "Flights",
                column: "DestinationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Locations_OriginId",
                table: "Flights",
                column: "OriginId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
