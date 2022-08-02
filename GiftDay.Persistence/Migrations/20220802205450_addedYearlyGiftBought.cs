using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiftDay.Persistence.Migrations
{
    public partial class addedYearlyGiftBought : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YearlyGiftBought",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Bought = table.Column<bool>(type: "INTEGER", nullable: false),
                    GiftEventId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearlyGiftBought", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YearlyGiftBought_EventsToCelebrate_GiftEventId",
                        column: x => x.GiftEventId,
                        principalTable: "EventsToCelebrate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_YearlyGiftBought_GiftEventId",
                table: "YearlyGiftBought",
                column: "GiftEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YearlyGiftBought");
        }
    }
}
