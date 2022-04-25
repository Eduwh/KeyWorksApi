using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyWorks.Api.Migrations
{
    public partial class Adding_priority_card : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Card",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 23, 13, 36, 49, 329, DateTimeKind.Utc).AddTicks(7147),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 23, 13, 32, 33, 615, DateTimeKind.Utc).AddTicks(3666));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Card",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Card");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Card",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 23, 13, 32, 33, 615, DateTimeKind.Utc).AddTicks(3666),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 23, 13, 36, 49, 329, DateTimeKind.Utc).AddTicks(7147));
        }
    }
}
