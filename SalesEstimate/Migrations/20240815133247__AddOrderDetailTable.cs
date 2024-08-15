using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesEstimate.Migrations
{
    /// <inheritdoc />
    public partial class _AddOrderDetailTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    FrameQty = table.Column<int>(type: "int", nullable: false),
                    LookupTypeId = table.Column<int>(type: "int", nullable: true),
                    LookupXifPairId = table.Column<int>(type: "int", nullable: true),
                    LookupOtherThanDoorId = table.Column<int>(type: "int", nullable: true),
                    ElevationDrawing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WidthFeet = table.Column<int>(type: "int", nullable: false),
                    WidthInches = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HeightFeet = table.Column<int>(type: "int", nullable: false),
                    HeightInches = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnequalPairWidthFeet = table.Column<int>(type: "int", nullable: false),
                    UnequalPairWidthInches = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LookupHandingId = table.Column<int>(type: "int", nullable: true),
                    LookupHandingTypeId = table.Column<int>(type: "int", nullable: true),
                    LookupSteelMaterialId = table.Column<int>(type: "int", nullable: true),
                    LookupFireLabelId = table.Column<int>(type: "int", nullable: true),
                    LookupSeriesId = table.Column<int>(type: "int", nullable: true),
                    LookupProfileId = table.Column<int>(type: "int", nullable: true),
                    LookupProfileOptionId = table.Column<int>(type: "int", nullable: true),
                    LookupReturnId = table.Column<int>(type: "int", nullable: true),
                    LookupGaugeId = table.Column<int>(type: "int", nullable: true),
                    JambDepth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HingeJamb = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StrikeJamb = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Head = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LookupAssemblyId = table.Column<int>(type: "int", nullable: true),
                    LookupAnchorsId = table.Column<int>(type: "int", nullable: true),
                    LookupAdditionalAnchorsId = table.Column<int>(type: "int", nullable: true),
                    QTY = table.Column<int>(type: "int", nullable: false),
                    LookupHingesId = table.Column<int>(type: "int", nullable: true),
                    LookupAdditionaloptionOnHingeId = table.Column<int>(type: "int", nullable: true),
                    LookupHardwareLocationId = table.Column<int>(type: "int", nullable: true),
                    LookupHeadPrepId = table.Column<int>(type: "int", nullable: true),
                    LookupStrikeId = table.Column<int>(type: "int", nullable: true),
                    LookupAdditionalStrikeId = table.Column<int>(type: "int", nullable: true),
                    LookupCloserId = table.Column<int>(type: "int", nullable: true),
                    LookupFinishId = table.Column<int>(type: "int", nullable: true),
                    LookupOptions1Id = table.Column<int>(type: "int", nullable: true),
                    LookupOptions2Id = table.Column<int>(type: "int", nullable: true),
                    LookupOptions3Id = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupAdditionalAnchorsId",
                        column: x => x.LookupAdditionalAnchorsId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupAdditionalStrikeId",
                        column: x => x.LookupAdditionalStrikeId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupAdditionaloptionOnHingeId",
                        column: x => x.LookupAdditionaloptionOnHingeId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupAnchorsId",
                        column: x => x.LookupAnchorsId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupAssemblyId",
                        column: x => x.LookupAssemblyId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupCloserId",
                        column: x => x.LookupCloserId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupFinishId",
                        column: x => x.LookupFinishId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupFireLabelId",
                        column: x => x.LookupFireLabelId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupGaugeId",
                        column: x => x.LookupGaugeId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupHandingTypeId",
                        column: x => x.LookupHandingTypeId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupHardwareLocationId",
                        column: x => x.LookupHardwareLocationId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupHeadPrepId",
                        column: x => x.LookupHeadPrepId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupHingesId",
                        column: x => x.LookupHingesId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupOptions1Id",
                        column: x => x.LookupOptions1Id,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupOptions2Id",
                        column: x => x.LookupOptions2Id,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupOptions3Id",
                        column: x => x.LookupOptions3Id,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupOtherThanDoorId",
                        column: x => x.LookupOtherThanDoorId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupProfileId",
                        column: x => x.LookupProfileId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupProfileOptionId",
                        column: x => x.LookupProfileOptionId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupReturnId",
                        column: x => x.LookupReturnId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupSeriesId",
                        column: x => x.LookupSeriesId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupSteelMaterialId",
                        column: x => x.LookupSteelMaterialId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupStrikeId",
                        column: x => x.LookupStrikeId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupTypeId",
                        column: x => x.LookupTypeId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_LookupValues_LookupXifPairId",
                        column: x => x.LookupXifPairId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupAdditionalAnchorsId",
                table: "OrderDetails",
                column: "LookupAdditionalAnchorsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupAdditionaloptionOnHingeId",
                table: "OrderDetails",
                column: "LookupAdditionaloptionOnHingeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupAdditionalStrikeId",
                table: "OrderDetails",
                column: "LookupAdditionalStrikeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupAnchorsId",
                table: "OrderDetails",
                column: "LookupAnchorsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupAssemblyId",
                table: "OrderDetails",
                column: "LookupAssemblyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupCloserId",
                table: "OrderDetails",
                column: "LookupCloserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupFinishId",
                table: "OrderDetails",
                column: "LookupFinishId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupFireLabelId",
                table: "OrderDetails",
                column: "LookupFireLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupGaugeId",
                table: "OrderDetails",
                column: "LookupGaugeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupHandingTypeId",
                table: "OrderDetails",
                column: "LookupHandingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupHardwareLocationId",
                table: "OrderDetails",
                column: "LookupHardwareLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupHeadPrepId",
                table: "OrderDetails",
                column: "LookupHeadPrepId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupHingesId",
                table: "OrderDetails",
                column: "LookupHingesId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupOptions1Id",
                table: "OrderDetails",
                column: "LookupOptions1Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupOptions2Id",
                table: "OrderDetails",
                column: "LookupOptions2Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupOptions3Id",
                table: "OrderDetails",
                column: "LookupOptions3Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupOtherThanDoorId",
                table: "OrderDetails",
                column: "LookupOtherThanDoorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupProfileId",
                table: "OrderDetails",
                column: "LookupProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupProfileOptionId",
                table: "OrderDetails",
                column: "LookupProfileOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupReturnId",
                table: "OrderDetails",
                column: "LookupReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupSeriesId",
                table: "OrderDetails",
                column: "LookupSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupSteelMaterialId",
                table: "OrderDetails",
                column: "LookupSteelMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupStrikeId",
                table: "OrderDetails",
                column: "LookupStrikeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupTypeId",
                table: "OrderDetails",
                column: "LookupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LookupXifPairId",
                table: "OrderDetails",
                column: "LookupXifPairId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");
        }
    }
}
