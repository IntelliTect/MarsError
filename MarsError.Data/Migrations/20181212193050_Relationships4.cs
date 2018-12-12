using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarsError.Data.Migrations
{
    public partial class Relationships4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Things_Kids_ParentId",
                table: "Things");

            migrationBuilder.DropIndex(
                name: "IX_Things_ParentId",
                table: "Things");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Things");

            migrationBuilder.CreateTable(
                name: "Frobs",
                columns: table => new
                {
                    FrobnitzId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Review = table.Column<string>(nullable: true),
                    ParentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frobs", x => x.FrobnitzId);
                    table.ForeignKey(
                        name: "FK_Frobs_Things_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Things",
                        principalColumn: "ThingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Frobs_ParentId",
                table: "Frobs",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frobs");

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "Things",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Things_ParentId",
                table: "Things",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Things_Kids_ParentId",
                table: "Things",
                column: "ParentId",
                principalTable: "Kids",
                principalColumn: "ChildId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
