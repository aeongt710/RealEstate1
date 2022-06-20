using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate1.Migrations
{
    public partial class societyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Societies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocietyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Societies");
        }
    }
}
