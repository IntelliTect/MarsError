using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarsError.Data.Migrations
{
    public partial class Relationships2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentChildId",
                table: "Things",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Kids",
                columns: table => new
                {
                    ChildId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ParentThingId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kids", x => x.ChildId);
                    table.ForeignKey(
                        name: "FK_Kids_Things_ParentThingId",
                        column: x => x.ParentThingId,
                        principalTable: "Things",
                        principalColumn: "ThingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Things_ParentChildId",
                table: "Things",
                column: "ParentChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Kids_ParentThingId",
                table: "Kids",
                column: "ParentThingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Things_Kids_ParentChildId",
                table: "Things",
                column: "ParentChildId",
                principalTable: "Kids",
                principalColumn: "ChildId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Things_Kids_ParentChildId",
                table: "Things");

            migrationBuilder.DropTable(
                name: "Kids");

            migrationBuilder.DropIndex(
                name: "IX_Things_ParentChildId",
                table: "Things");

            migrationBuilder.DropColumn(
                name: "ParentChildId",
                table: "Things");
        }
    }
}
