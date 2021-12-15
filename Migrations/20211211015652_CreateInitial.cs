using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Migrations
{
  public partial class CreateInitial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "ProductType",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ProductType", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "User",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
            Surname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
            Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Cellphone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
            Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            Neighborhood = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
            UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_User", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Product",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            ProductTypeId = table.Column<int>(type: "int", nullable: true),
            Sku = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
            Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            Value = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
            StockAmount = table.Column<int>(type: "int", nullable: false),
            ProductUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Product", x => x.Id);
            table.ForeignKey(
                      name: "FK_Product_ProductType_ProductTypeId",
                      column: x => x.ProductTypeId,
                      principalTable: "ProductType",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateIndex(
          name: "IX_PRODUCT_PRODUCTTYPE",
          table: "Product",
          column: "ProductTypeId");

      migrationBuilder.CreateIndex(
          name: "IX_PRODUCT_SKU",
          table: "Product",
          column: "ProductTypeId");

      migrationBuilder.CreateIndex(
          name: "IX_USER_CPF",
          table: "User",
          column: "CPF");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Product");

      migrationBuilder.DropTable(
          name: "User");

      migrationBuilder.DropTable(
          name: "ProductType");
    }
  }
}
