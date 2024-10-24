using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesEstimate.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LookupValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookupTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CustomField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomField3 = table.Column<float>(type: "real", nullable: true),
                    CustomField4 = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookupValues_LookupTypes_LookupTypeId",
                        column: x => x.LookupTypeId,
                        principalTable: "LookupTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentOrderId = table.Column<int>(type: "int", nullable: true),
                    RevisionNumber = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JobSiteContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JobSiteName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuotationRequest = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerPurchaseOrder = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ContactFax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsBuyAmericaActProject = table.Column<bool>(type: "bit", nullable: true),
                    IsActivatePriceCalculation = table.Column<bool>(type: "bit", nullable: true),
                    IsPurchaseOrderQuoted = table.Column<bool>(type: "bit", nullable: true),
                    ProjectTotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QuoteNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ShipToAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LookupStateId = table.Column<int>(type: "int", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Contractor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    JobSiteContactPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AdditionalShippingInstructions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Standard = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fastlane = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Express = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Turbo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_LookupValues_LookupStateId",
                        column: x => x.LookupStateId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrderLine = table.Column<int>(type: "int", nullable: true),
                    FrameQty = table.Column<int>(type: "int", nullable: true),
                    EstimatedSubTotal = table.Column<int>(type: "int", nullable: true),
                    AdditionalCharges = table.Column<int>(type: "int", nullable: true),
                    OtherCharges = table.Column<int>(type: "int", nullable: true),
                    EstimatedFreight = table.Column<int>(type: "int", nullable: true),
                    EstimatedTotal = table.Column<int>(type: "int", nullable: true),
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LookupValues_LookupTypeId",
                table: "LookupValues",
                column: "LookupTypeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LookupStateId",
                table: "Orders",
                column: "LookupStateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "LookupValues");

            migrationBuilder.DropTable(
                name: "LookupTypes");
        }
    }
}
