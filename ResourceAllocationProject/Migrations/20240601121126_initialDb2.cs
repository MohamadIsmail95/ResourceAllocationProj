using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceAllocationProject.Migrations
{
    /// <inheritdoc />
    public partial class initialDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlanID",
                table: "AliMointorPlans",
                newName: "PlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "AliMointorPlans",
                newName: "PlanID");
        }
    }
}
