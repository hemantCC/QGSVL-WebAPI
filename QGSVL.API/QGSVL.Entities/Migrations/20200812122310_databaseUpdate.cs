using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QGSVL.EntityLayer.Migrations
{
    public partial class databaseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblBankDetail",
                columns: table => new
                {
                    IbanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuoteId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    IbanNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBankDetail", x => x.IbanId);
                    table.ForeignKey(
                        name: "FK_tblBankDetail_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblContractType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblContractType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblDocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblEmploymentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmploymentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblIncludedServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblIncludedServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblInsurance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Term = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblInsurance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblMaritalStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMaritalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblMileage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MileageInKms = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMileage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblNationality",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNationality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPaybackTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaybackInMonths = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPaybackTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPropertyStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPropertyStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblQuoteStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblQuoteStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblDocument",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    QuoteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblDocument_tblDocumentType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "tblDocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblUserProfile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    IsMainDriver = table.Column<bool>(nullable: false),
                    MaritalStatusId = table.Column<int>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    LivedSince = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblUserProfile_tblMaritalStatus_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "tblMaritalStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblUserProfile_tblNationality_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "tblNationality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblDriver",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProileId = table.Column<int>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDriver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblDriver_tblUserProfile_UserProileId",
                        column: x => x.UserProileId,
                        principalTable: "tblUserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployementDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileId = table.Column<int>(nullable: true),
                    EmployerName = table.Column<string>(nullable: true),
                    ContractTypeId = table.Column<int>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EmploymentStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployementDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmployementDetail_tblContractType_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "tblContractType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblEmployementDetail_tblEmploymentStatus_EmploymentStatusId",
                        column: x => x.EmploymentStatusId,
                        principalTable: "tblEmploymentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblEmployementDetail_tblUserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "tblUserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblRentDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    NetIncomeInMonths = table.Column<int>(nullable: false),
                    RentalIncome = table.Column<int>(nullable: false),
                    PropertyStatusId = table.Column<int>(nullable: true),
                    CreditCost = table.Column<int>(nullable: false),
                    MonthlyRent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblRentDetail_tblPropertyStatus_PropertyStatusId",
                        column: x => x.PropertyStatusId,
                        principalTable: "tblPropertyStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblRentDetail_tblUserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblVehicleDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    ModelName = table.Column<string>(nullable: true),
                    HorsePower = table.Column<string>(nullable: true),
                    FuelConsumption = table.Column<string>(nullable: true),
                    CO2Emission = table.Column<string>(nullable: true),
                    FuelType = table.Column<string>(nullable: true),
                    Seating = table.Column<int>(nullable: false),
                    ABS = table.Column<bool>(nullable: false),
                    Airbag = table.Column<int>(nullable: false),
                    Transmission = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    UserProfileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVehicleDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblVehicleDetail_tblUserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "tblUserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(nullable: true),
                    EquipmentType = table.Column<string>(nullable: true),
                    Features = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEquipment_tblVehicleDetail_CarId",
                        column: x => x.CarId,
                        principalTable: "tblVehicleDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblQuote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    CarId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    InsuranceId = table.Column<int>(nullable: true),
                    MileageId = table.Column<int>(nullable: true),
                    TotalPrice = table.Column<int>(nullable: false),
                    QuoteStatusId = table.Column<int>(nullable: true),
                    PaybackTimeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblQuote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblQuote_tblVehicleDetail_CarId",
                        column: x => x.CarId,
                        principalTable: "tblVehicleDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblQuote_tblInsurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "tblInsurance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblQuote_tblMileage_MileageId",
                        column: x => x.MileageId,
                        principalTable: "tblMileage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblQuote_tblPaybackTime_PaybackTimeId",
                        column: x => x.PaybackTimeId,
                        principalTable: "tblPaybackTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblQuote_tblQuoteStatus_QuoteStatusId",
                        column: x => x.QuoteStatusId,
                        principalTable: "tblQuoteStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblQuote_tblUserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblBankDetail_UserId",
                table: "tblBankDetail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDocument_TypeId",
                table: "tblDocument",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDriver_UserProileId",
                table: "tblDriver",
                column: "UserProileId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployementDetail_ContractTypeId",
                table: "tblEmployementDetail",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployementDetail_EmploymentStatusId",
                table: "tblEmployementDetail",
                column: "EmploymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployementDetail_UserProfileId",
                table: "tblEmployementDetail",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEquipment_CarId",
                table: "tblEquipment",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_tblQuote_CarId",
                table: "tblQuote",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_tblQuote_InsuranceId",
                table: "tblQuote",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblQuote_MileageId",
                table: "tblQuote",
                column: "MileageId");

            migrationBuilder.CreateIndex(
                name: "IX_tblQuote_PaybackTimeId",
                table: "tblQuote",
                column: "PaybackTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblQuote_QuoteStatusId",
                table: "tblQuote",
                column: "QuoteStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tblQuote_UserId",
                table: "tblQuote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRentDetail_PropertyStatusId",
                table: "tblRentDetail",
                column: "PropertyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRentDetail_UserId",
                table: "tblRentDetail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserProfile_MaritalStatusId",
                table: "tblUserProfile",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserProfile_NationalityId",
                table: "tblUserProfile",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_tblVehicleDetail_UserProfileId",
                table: "tblVehicleDetail",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblBankDetail");

            migrationBuilder.DropTable(
                name: "tblDocument");

            migrationBuilder.DropTable(
                name: "tblDriver");

            migrationBuilder.DropTable(
                name: "tblEmployementDetail");

            migrationBuilder.DropTable(
                name: "tblEquipment");

            migrationBuilder.DropTable(
                name: "tblIncludedServices");

            migrationBuilder.DropTable(
                name: "tblQuote");

            migrationBuilder.DropTable(
                name: "tblRentDetail");

            migrationBuilder.DropTable(
                name: "tblDocumentType");

            migrationBuilder.DropTable(
                name: "tblContractType");

            migrationBuilder.DropTable(
                name: "tblEmploymentStatus");

            migrationBuilder.DropTable(
                name: "tblVehicleDetail");

            migrationBuilder.DropTable(
                name: "tblInsurance");

            migrationBuilder.DropTable(
                name: "tblMileage");

            migrationBuilder.DropTable(
                name: "tblPaybackTime");

            migrationBuilder.DropTable(
                name: "tblQuoteStatus");

            migrationBuilder.DropTable(
                name: "tblPropertyStatus");

            migrationBuilder.DropTable(
                name: "tblUserProfile");

            migrationBuilder.DropTable(
                name: "tblMaritalStatus");

            migrationBuilder.DropTable(
                name: "tblNationality");
        }
    }
}
