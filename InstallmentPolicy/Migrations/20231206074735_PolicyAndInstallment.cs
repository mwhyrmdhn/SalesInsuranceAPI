using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstallmentPolicy.Migrations
{
    /// <inheritdoc />
    public partial class PolicyAndInstallment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterPolicy",
                columns: table => new
                {
                    PID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Policy_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Of_Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Card = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Premium = table.Column<float>(type: "real", nullable: false),
                    Plan_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Update_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterPolicy", x => x.PID);
                });

            migrationBuilder.CreateTable(
                name: "InstallmentPolicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PID = table.Column<int>(type: "int", nullable: false),
                    Policy_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Installment_No = table.Column<int>(type: "int", nullable: false),
                    Premium = table.Column<float>(type: "real", nullable: true),
                    Paydate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_On = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentPolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstallmentPolicy_MasterPolicy_PID",
                        column: x => x.PID,
                        principalTable: "MasterPolicy",
                        principalColumn: "PID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentPolicy_PID",
                table: "InstallmentPolicy",
                column: "PID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstallmentPolicy");

            migrationBuilder.DropTable(
                name: "MasterPolicy");
        }
    }
}
