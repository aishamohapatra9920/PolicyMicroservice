using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PolicyMicroservice.Migrations
{
    public partial class InsureityPortal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessMasters",
                columns: table => new
                {
                    BusinessMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessValue = table.Column<int>(type: "int", nullable: false),
                    BusinessTurnOver = table.Column<int>(type: "int", nullable: false),
                    CapitalInvest = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessMasters", x => x.BusinessMasterId);
                });

            migrationBuilder.CreateTable(
                name: "PolicyMasters",
                columns: table => new
                {
                    PolicyMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsumerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssuredSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tenure = table.Column<int>(type: "int", nullable: false),
                    BusinesssValue = table.Column<int>(type: "int", nullable: false),
                    PropertyValue = table.Column<int>(type: "int", nullable: false),
                    BaseLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyMasters", x => x.PolicyMasterId);
                });

            migrationBuilder.CreateTable(
                name: "PropertyMasters",
                columns: table => new
                {
                    PropertyMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostOfAssest = table.Column<int>(type: "int", nullable: false),
                    SalvageValue = table.Column<int>(type: "int", nullable: false),
                    UsefulLifeOfAssest = table.Column<int>(type: "int", nullable: false),
                    PropertyValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyMasters", x => x.PropertyMasterId);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyValueFrom = table.Column<int>(type: "int", nullable: false),
                    PropertyValueTo = table.Column<int>(type: "int", nullable: false),
                    BusinesssValueFrom = table.Column<int>(type: "int", nullable: false),
                    BusinesssValueTo = table.Column<int>(type: "int", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuoteValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                });

            migrationBuilder.CreateTable(
                name: "Consumers",
                columns: table => new
                {
                    ConsumerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PanNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumers", x => x.ConsumerId);
                    table.ForeignKey(
                        name: "FK_Consumers_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalEmployees = table.Column<int>(type: "int", nullable: false),
                    BusinessMasterId = table.Column<int>(type: "int", nullable: false),
                    ConsumerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK_Businesses_BusinessMasters_BusinessMasterId",
                        column: x => x.BusinessMasterId,
                        principalTable: "BusinessMasters",
                        principalColumn: "BusinessMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Businesses_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "ConsumerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingStoreys = table.Column<int>(type: "int", nullable: false),
                    BuildingAge = table.Column<int>(type: "int", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    PropertyMasterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Properties_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyMasters_PropertyMasterId",
                        column: x => x.PropertyMasterId,
                        principalTable: "PropertyMasters",
                        principalColumn: "PropertyMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerPolicies",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    PolicyStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyMasterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerPolicies", x => x.PolicyId);
                    table.ForeignKey(
                        name: "FK_ConsumerPolicies_PolicyMasters_PolicyMasterId",
                        column: x => x.PolicyMasterId,
                        principalTable: "PolicyMasters",
                        principalColumn: "PolicyMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumerPolicies_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumerPolicies_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "QuoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_BusinessMasterId",
                table: "Businesses",
                column: "BusinessMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_ConsumerId",
                table: "Businesses",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerPolicies_PolicyMasterId",
                table: "ConsumerPolicies",
                column: "PolicyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerPolicies_PropertyId",
                table: "ConsumerPolicies",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerPolicies_QuoteId",
                table: "ConsumerPolicies",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumers_AgentId",
                table: "Consumers",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_BusinessId",
                table: "Properties",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyMasterId",
                table: "Properties",
                column: "PropertyMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumerPolicies");

            migrationBuilder.DropTable(
                name: "PolicyMasters");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "PropertyMasters");

            migrationBuilder.DropTable(
                name: "BusinessMasters");

            migrationBuilder.DropTable(
                name: "Consumers");

            migrationBuilder.DropTable(
                name: "Agents");
        }
    }
}
