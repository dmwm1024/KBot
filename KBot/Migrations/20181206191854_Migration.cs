using Microsoft.EntityFrameworkCore.Migrations;

namespace KBot.Migrations
{
    public partial class Migration : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<ulong>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BdayMonth = table.Column<int>(nullable: false),
                    BdayDay = table.Column<int>(nullable: false),
                    BattleTag = table.Column<string>(nullable: true),
                    IsProfilePrivate = table.Column<bool>(nullable: false),
                    CompetitiveRank = table.Column<ushort>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsLive = table.Column<bool>(nullable: false),
                    Preview = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Banner = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Views = table.Column<int>(nullable: false),
                    Followers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
