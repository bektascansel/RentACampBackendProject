using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_userId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentalls_Cars_carId",
                table: "Rentalls");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentalls_Customers_customerId",
                table: "Rentalls");

            migrationBuilder.RenameColumn(
                name: "carId",
                table: "Rentalls",
                newName: "CarId");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Rentalls",
                newName: "CustumorId");

            migrationBuilder.RenameIndex(
                name: "IX_Rentalls_carId",
                table: "Rentalls",
                newName: "IX_Rentalls_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Rentalls_customerId",
                table: "Rentalls",
                newName: "IX_Rentalls_CustumorId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Customers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_userId",
                table: "Customers",
                newName: "IX_Customers_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentalls_Cars_CarId",
                table: "Rentalls",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentalls_Customers_CustumorId",
                table: "Rentalls",
                column: "CustumorId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentalls_Cars_CarId",
                table: "Rentalls");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentalls_Customers_CustumorId",
                table: "Rentalls");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Rentalls",
                newName: "carId");

            migrationBuilder.RenameColumn(
                name: "CustumorId",
                table: "Rentalls",
                newName: "customerId");

            migrationBuilder.RenameIndex(
                name: "IX_Rentalls_CarId",
                table: "Rentalls",
                newName: "IX_Rentalls_carId");

            migrationBuilder.RenameIndex(
                name: "IX_Rentalls_CustumorId",
                table: "Rentalls",
                newName: "IX_Rentalls_customerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Customers",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                newName: "IX_Customers_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_userId",
                table: "Customers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentalls_Cars_carId",
                table: "Rentalls",
                column: "carId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentalls_Customers_customerId",
                table: "Rentalls",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
