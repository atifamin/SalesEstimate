using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesEstimate.Migrations
{
    /// <inheritdoc />
    public partial class _UpdateModelClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookupValues_LookupTypes_LookupTypeId",
                table: "LookupValues");

            migrationBuilder.AddColumn<string>(
                name: "QuotationRequest",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "LookupTypeId",
                table: "LookupValues",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LookupValues_LookupTypes_LookupTypeId",
                table: "LookupValues",
                column: "LookupTypeId",
                principalTable: "LookupTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookupValues_LookupTypes_LookupTypeId",
                table: "LookupValues");

            migrationBuilder.DropColumn(
                name: "QuotationRequest",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "LookupTypeId",
                table: "LookupValues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LookupValues_LookupTypes_LookupTypeId",
                table: "LookupValues",
                column: "LookupTypeId",
                principalTable: "LookupTypes",
                principalColumn: "Id");
        }
    }
}
