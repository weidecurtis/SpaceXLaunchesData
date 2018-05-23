using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SpaceXLaunchData.Migrations
{
    public partial class DeletedFlightID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightID",
                table: "Launches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightID",
                table: "Launches",
                nullable: false,
                defaultValue: 0);
        }
    }
}
