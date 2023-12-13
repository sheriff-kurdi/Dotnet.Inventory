using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kurdi.Inventory.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationnaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    isparent = table.Column<bool>(name: "is_parent", type: "bit", nullable: false),
                    parent = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    activation = table.Column<bool>(type: "bit", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.name);
                    table.ForeignKey(
                        name: "FK_categories_categories_parent",
                        column: x => x.parent,
                        principalTable: "categories",
                        principalColumn: "name");
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    languagecode = table.Column<string>(name: "language_code", type: "nvarchar(450)", nullable: false),
                    languagename = table.Column<string>(name: "language_name", type: "nvarchar(max)", nullable: true),
                    activation = table.Column<bool>(type: "bit", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.languagecode);
                });

            migrationBuilder.CreateTable(
                name: "sales_order_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_order_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    sku = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    supplieridentity = table.Column<int>(name: "supplier_identity", type: "int", nullable: false),
                    sellingprice = table.Column<double>(name: "selling_price", type: "float", nullable: true),
                    costprice = table.Column<double>(name: "cost_price", type: "float", nullable: true),
                    discount = table.Column<double>(type: "float", nullable: true),
                    isdiscounted = table.Column<bool>(name: "is_discounted", type: "bit", nullable: true),
                    totalstock = table.Column<int>(name: "total_stock", type: "int", nullable: true),
                    availablestock = table.Column<int>(name: "available_stock", type: "int", nullable: true),
                    reservedstock = table.Column<int>(name: "reserved_stock", type: "int", nullable: true),
                    category = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    activation = table.Column<bool>(type: "bit", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.sku);
                    table.ForeignKey(
                        name: "FK_products_categories_category",
                        column: x => x.category,
                        principalTable: "categories",
                        principalColumn: "name");
                });

            migrationBuilder.CreateTable(
                name: "categories_details",
                columns: table => new
                {
                    languagecode = table.Column<string>(name: "language_code", type: "nvarchar(450)", nullable: false),
                    translatedname = table.Column<string>(name: "translated_name", type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories_details", x => new { x.languagecode, x.translatedname });
                    table.ForeignKey(
                        name: "FK_categories_details_categories_name",
                        column: x => x.name,
                        principalTable: "categories",
                        principalColumn: "name");
                    table.ForeignKey(
                        name: "FK_categories_details_languages_language_code",
                        column: x => x.languagecode,
                        principalTable: "languages",
                        principalColumn: "language_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sales_orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalprice = table.Column<double>(name: "total_price", type: "float", nullable: false),
                    discount = table.Column<double>(type: "float", nullable: false),
                    statusid = table.Column<int>(name: "status_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_sales_orders_sales_order_status_status_id",
                        column: x => x.statusid,
                        principalTable: "sales_order_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_details",
                columns: table => new
                {
                    languagecode = table.Column<string>(name: "language_code", type: "nvarchar(450)", nullable: false),
                    sku = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_details", x => new { x.languagecode, x.sku });
                    table.ForeignKey(
                        name: "FK_product_details_languages_language_code",
                        column: x => x.languagecode,
                        principalTable: "languages",
                        principalColumn: "language_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_details_products_sku",
                        column: x => x.sku,
                        principalTable: "products",
                        principalColumn: "sku",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sales_order_products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salesorderid = table.Column<int>(name: "sales_order_id", type: "int", nullable: false),
                    sku = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    costpriceperitem = table.Column<double>(name: "cost_price_per_item", type: "float", nullable: false),
                    sellingpriceperitem = table.Column<double>(name: "selling_price_per_item", type: "float", nullable: false),
                    discountperitem = table.Column<double>(name: "discount_per_item", type: "float", nullable: false),
                    sellingpriceperitembeforediscount = table.Column<double>(name: "selling_price_per_item_before_discount", type: "float", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_order_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_sales_order_products_products_sku",
                        column: x => x.sku,
                        principalTable: "products",
                        principalColumn: "sku");
                    table.ForeignKey(
                        name: "FK_sales_order_products_sales_orders_sales_order_id",
                        column: x => x.salesorderid,
                        principalTable: "sales_orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_parent",
                table: "categories",
                column: "parent");

            migrationBuilder.CreateIndex(
                name: "IX_categories_details_name",
                table: "categories_details",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_product_details_sku",
                table: "product_details",
                column: "sku");

            migrationBuilder.CreateIndex(
                name: "IX_products_category",
                table: "products",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "IX_sales_order_products_sales_order_id",
                table: "sales_order_products",
                column: "sales_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_order_products_sku",
                table: "sales_order_products",
                column: "sku");

            migrationBuilder.CreateIndex(
                name: "IX_sales_orders_status_id",
                table: "sales_orders",
                column: "status_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories_details");

            migrationBuilder.DropTable(
                name: "product_details");

            migrationBuilder.DropTable(
                name: "sales_order_products");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "sales_orders");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "sales_order_status");
        }
    }
}
