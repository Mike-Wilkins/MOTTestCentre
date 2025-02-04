using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KwikFitTestCentreApi.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorisedMOTTesters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorisedMOTTesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MOTStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfRegistration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CylinderCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CO2Emissions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EuroStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealDrivingEmissions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExportMarker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleColour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleTypeApproval = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WheelPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevenueWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfLastV5C = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Taxed = table.Column<bool>(type: "bit", nullable: false),
                    TaxDueDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfLastTAX = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MOTed = table.Column<bool>(type: "bit", nullable: false),
                    MOTDueDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfLastMOT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOTStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MOTTestCertificateDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryOfRegistration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mileage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfTest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EariestTestDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestOrganisation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspectorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MOTTestNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOTTestCertificateDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorisedMOTTesters");

            migrationBuilder.DropTable(
                name: "MOTStatus");

            migrationBuilder.DropTable(
                name: "MOTTestCertificateDetails");
        }
    }
}
