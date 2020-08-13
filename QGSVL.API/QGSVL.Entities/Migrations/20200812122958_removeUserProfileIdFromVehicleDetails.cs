using Microsoft.EntityFrameworkCore.Migrations;

namespace QGSVL.EntityLayer.Migrations
{
    public partial class removeUserProfileIdFromVehicleDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblVehicleDetail_tblUserProfile_UserProfileId",
                table: "tblVehicleDetail");

            migrationBuilder.DropIndex(
                name: "IX_tblVehicleDetail_UserProfileId",
                table: "tblVehicleDetail");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "tblVehicleDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "tblVehicleDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblVehicleDetail_UserProfileId",
                table: "tblVehicleDetail",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblVehicleDetail_tblUserProfile_UserProfileId",
                table: "tblVehicleDetail",
                column: "UserProfileId",
                principalTable: "tblUserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
