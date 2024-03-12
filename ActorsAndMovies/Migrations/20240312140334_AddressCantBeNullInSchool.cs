using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActorsAndMovies.Migrations
{
    /// <inheritdoc />
    public partial class AddressCantBeNullInSchool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ActingSchools_AddressId",
                table: "ActingSchools",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActingSchools_Addresses_AddressId",
                table: "ActingSchools",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActingSchools_Addresses_AddressId",
                table: "ActingSchools");

            migrationBuilder.DropIndex(
                name: "IX_ActingSchools_AddressId",
                table: "ActingSchools");
        }
    }
}
