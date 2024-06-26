using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceAllocationProject.Migrations
{
    /// <inheritdoc />
    public partial class initialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AliMointorPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvayaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    M1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    M2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    M3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AliMointorPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AliMonitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AliMonitors", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AliMointorPlans");

            migrationBuilder.DropTable(
                name: "AliMonitors");
        }
    }
}
