using Microsoft.EntityFrameworkCore.Migrations;

namespace MarsError.Data.Migrations
{
    public partial class Relationships3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kids_Things_ParentThingId",
                table: "Kids");

            migrationBuilder.DropForeignKey(
                name: "FK_Things_Kids_ParentChildId",
                table: "Things");

            migrationBuilder.DropIndex(
                name: "IX_Things_ParentChildId",
                table: "Things");

            migrationBuilder.DropIndex(
                name: "IX_Kids_ParentThingId",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "ParentChildId",
                table: "Things");

            migrationBuilder.DropColumn(
                name: "ParentThingId",
                table: "Kids");

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "Things",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "Kids",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Things_ParentId",
                table: "Things",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Kids_ParentId",
                table: "Kids",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kids_Things_ParentId",
                table: "Kids",
                column: "ParentId",
                principalTable: "Things",
                principalColumn: "ThingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Things_Kids_ParentId",
                table: "Things",
                column: "ParentId",
                principalTable: "Kids",
                principalColumn: "ChildId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kids_Things_ParentId",
                table: "Kids");

            migrationBuilder.DropForeignKey(
                name: "FK_Things_Kids_ParentId",
                table: "Things");

            migrationBuilder.DropIndex(
                name: "IX_Things_ParentId",
                table: "Things");

            migrationBuilder.DropIndex(
                name: "IX_Kids_ParentId",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Things");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Kids");

            migrationBuilder.AddColumn<long>(
                name: "ParentChildId",
                table: "Things",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentThingId",
                table: "Kids",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Things_ParentChildId",
                table: "Things",
                column: "ParentChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Kids_ParentThingId",
                table: "Kids",
                column: "ParentThingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kids_Things_ParentThingId",
                table: "Kids",
                column: "ParentThingId",
                principalTable: "Things",
                principalColumn: "ThingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Things_Kids_ParentChildId",
                table: "Things",
                column: "ParentChildId",
                principalTable: "Kids",
                principalColumn: "ChildId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
