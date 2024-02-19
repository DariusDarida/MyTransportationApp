using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTransportationApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTransportationReferenceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stop",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StopName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stop", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stop_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Train",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransporterID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Train_Transporter_TransporterID",
                        column: x => x.TransporterID,
                        principalTable: "Transporter",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransporterID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vehicle_Transporter_TransporterID",
                        column: x => x.TransporterID,
                        principalTable: "Transporter",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stop_CityID",
                table: "Stop",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Train_TransporterID",
                table: "Train",
                column: "TransporterID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_TransporterID",
                table: "Vehicle",
                column: "TransporterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stop");

            migrationBuilder.DropTable(
                name: "Train");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
