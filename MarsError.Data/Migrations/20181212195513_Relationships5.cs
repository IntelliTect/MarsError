using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarsError.Data.Migrations
{
    public partial class Relationships5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frobs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frobs",
                columns: table => new
                {
                    FrobnitzId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<long>(nullable: false),
                    Review = table.Column<string>(nullable: true)
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
    }
}
