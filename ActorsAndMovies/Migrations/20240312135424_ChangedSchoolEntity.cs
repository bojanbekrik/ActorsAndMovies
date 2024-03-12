using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActorsAndMovies.Migrations
{
    /// <inheritdoc />
    public partial class ChangedSchoolEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "ActingSchools",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "ActingSchools");
        }
    }
}
