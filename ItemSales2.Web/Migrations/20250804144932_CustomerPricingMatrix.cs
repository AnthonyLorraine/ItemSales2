using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemSales2.Web.Migrations
{
    /// <inheritdoc />
    public partial class CustomerPricingMatrix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PricingId",
                schema: "SalesOrder",
                table: "Contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Pricing",
                schema: "SalesOrder",
                columns: table => new
                {
                    PricingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricing", x => x.PricingId);
                });

            migrationBuilder.CreateTable(
                name: "PricingMatrix",
                schema: "SalesOrder",
                columns: table => new
                {
                    PricingMatrixId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    EndPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    Markup = table.Column<decimal>(type: "TEXT", nullable: false),
                    PricingModelPricingId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingMatrix", x => x.PricingMatrixId);
                    table.ForeignKey(
                        name: "FK_PricingMatrix_Pricing_PricingModelPricingId",
                        column: x => x.PricingModelPricingId,
                        principalSchema: "SalesOrder",
                        principalTable: "Pricing",
                        principalColumn: "PricingId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PricingId",
                schema: "SalesOrder",
                table: "Contacts",
                column: "PricingId");

            migrationBuilder.CreateIndex(
                name: "IX_PricingMatrix_PricingModelPricingId",
                schema: "SalesOrder",
                table: "PricingMatrix",
                column: "PricingModelPricingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Pricing_PricingId",
                schema: "SalesOrder",
                table: "Contacts",
                column: "PricingId",
                principalSchema: "SalesOrder",
                principalTable: "Pricing",
                principalColumn: "PricingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Pricing_PricingId",
                schema: "SalesOrder",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "PricingMatrix",
                schema: "SalesOrder");

            migrationBuilder.DropTable(
                name: "Pricing",
                schema: "SalesOrder");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_PricingId",
                schema: "SalesOrder",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "PricingId",
                schema: "SalesOrder",
                table: "Contacts");
        }
    }
}
