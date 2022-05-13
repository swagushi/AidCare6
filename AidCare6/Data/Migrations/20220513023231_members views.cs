using Microsoft.EntityFrameworkCore.Migrations;

namespace AidCare6.Data.Migrations
{
    public partial class membersviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    eventsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventsLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eventsDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.eventsID);
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    membersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.membersId);
                });

            migrationBuilder.CreateTable(
                name: "donations",
                columns: table => new
                {
                    donationsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonationsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    donationsAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    membersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donations", x => x.donationsID);
                    table.ForeignKey(
                        name: "FK_donations_members_membersID",
                        column: x => x.membersID,
                        principalTable: "members",
                        principalColumn: "membersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "membersevents",
                columns: table => new
                {
                    memberseventsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    memberseventsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRegistered = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    membersID = table.Column<int>(type: "int", nullable: false),
                    eventsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membersevents", x => x.memberseventsId);
                    table.ForeignKey(
                        name: "FK_membersevents_events_eventsID",
                        column: x => x.eventsID,
                        principalTable: "events",
                        principalColumn: "eventsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_membersevents_members_membersID",
                        column: x => x.membersID,
                        principalTable: "members",
                        principalColumn: "membersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_donations_membersID",
                table: "donations",
                column: "membersID");

            migrationBuilder.CreateIndex(
                name: "IX_membersevents_eventsID",
                table: "membersevents",
                column: "eventsID");

            migrationBuilder.CreateIndex(
                name: "IX_membersevents_membersID",
                table: "membersevents",
                column: "membersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "donations");

            migrationBuilder.DropTable(
                name: "membersevents");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "members");
        }
    }
}
