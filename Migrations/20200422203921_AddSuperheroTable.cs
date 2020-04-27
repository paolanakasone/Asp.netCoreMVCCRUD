using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.netCoreMVCCRUD.Migrations
{
    public partial class AddSuperheroTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Superhero",
                columns: table => new
                {
                    SuperheroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nvarchar200 = table.Column<string>(name: "nvarchar(200)", nullable: false),
                    Power = table.Column<string>(type: "varchar(100)", nullable: true),
                    Editorial = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superhero", x => x.SuperheroId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Superhero");
        }
    }
}
