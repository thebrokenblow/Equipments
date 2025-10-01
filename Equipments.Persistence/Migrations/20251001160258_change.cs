using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Equipments.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equipments_facilities_facility_id",
                table: "equipments");

            migrationBuilder.AddForeignKey(
                name: "FK_equipments_facilities_facility_id",
                table: "equipments",
                column: "facility_id",
                principalTable: "facilities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equipments_facilities_facility_id",
                table: "equipments");

            migrationBuilder.AddForeignKey(
                name: "FK_equipments_facilities_facility_id",
                table: "equipments",
                column: "facility_id",
                principalTable: "facilities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
