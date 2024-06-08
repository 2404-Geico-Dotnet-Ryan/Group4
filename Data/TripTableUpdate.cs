using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group4.Migrations
{
    /// <inheritdoc />
    public partial class TripTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropPrimaryKey(
                name: "PK_Id",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Trips");

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Trips",
                nullable: false)
                 .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripId",
                table: "Trips",
                column: "TripId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}