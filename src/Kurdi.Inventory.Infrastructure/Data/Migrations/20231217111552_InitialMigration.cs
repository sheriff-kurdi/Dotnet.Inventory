using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kurdi.Inventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: false),
                    has_parent = table.Column<bool>(type: "boolean", nullable: false),
                    parent_name = table.Column<string>(type: "text", nullable: true),
                    activation = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.name);
                    table.ForeignKey(
                        name: "fk_categories_categories_parent_temp_id1",
                        column: x => x.parent_name,
                        principalTable: "categories",
                        principalColumn: "name");
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    language_code = table.Column<string>(type: "text", nullable: false),
                    language_name = table.Column<string>(type: "text", nullable: true),
                    activation = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_languages", x => x.language_code);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    sku = table.Column<string>(type: "text", nullable: false),
                    supplier_identity = table.Column<int>(type: "integer", nullable: false),
                    selling_price = table.Column<double>(type: "double precision", nullable: true),
                    cost_price = table.Column<double>(type: "double precision", nullable: true),
                    discount = table.Column<double>(type: "double precision", nullable: true),
                    is_discounted = table.Column<bool>(type: "boolean", nullable: true),
                    total_stock = table.Column<int>(type: "integer", nullable: true),
                    available_stock = table.Column<int>(type: "integer", nullable: true),
                    reserved_stock = table.Column<int>(type: "integer", nullable: true),
                    category_name = table.Column<string>(type: "text", nullable: false),
                    activation = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.sku);
                    table.ForeignKey(
                        name: "fk_products_categories_category_temp_id2",
                        column: x => x.category_name,
                        principalTable: "categories",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categories_details",
                columns: table => new
                {
                    language_code = table.Column<string>(type: "text", nullable: false),
                    category_name = table.Column<string>(type: "text", nullable: false),
                    translated_name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories_details", x => new { x.language_code, x.category_name });
                    table.ForeignKey(
                        name: "fk_categories_details_categories_category_name1",
                        column: x => x.category_name,
                        principalTable: "categories",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_categories_details_categories_category_temp_id",
                        column: x => x.name,
                        principalTable: "categories",
                        principalColumn: "name");
                    table.ForeignKey(
                        name: "fk_categories_details_languages_language_temp_id",
                        column: x => x.language_code,
                        principalTable: "languages",
                        principalColumn: "language_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_details",
                columns: table => new
                {
                    language_code = table.Column<string>(type: "text", nullable: false),
                    sku = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    product_sku = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_details", x => new { x.language_code, x.sku });
                    table.ForeignKey(
                        name: "fk_product_details_languages_language_temp_id1",
                        column: x => x.language_code,
                        principalTable: "languages",
                        principalColumn: "language_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_product_details_products_product_sku",
                        column: x => x.product_sku,
                        principalTable: "products",
                        principalColumn: "sku");
                    table.ForeignKey(
                        name: "fk_product_details_products_product_temp_id",
                        column: x => x.sku,
                        principalTable: "products",
                        principalColumn: "sku",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "name", "activation", "has_parent", "parent_name", "created_at", "deleted_at", "updated_at" },
                values: new object[,]
                {
                    { "MEN", true, false, null, new DateTime(2023, 12, 17, 11, 15, 52, 322, DateTimeKind.Utc).AddTicks(4107), null, null },
                    { "WOMEN", true, false, null, new DateTime(2023, 12, 17, 11, 15, 52, 322, DateTimeKind.Utc).AddTicks(4109), null, null }
                });

            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "language_code", "activation", "language_name", "created_at", "deleted_at", "updated_at" },
                values: new object[,]
                {
                    { "ar", true, "Arabic", new DateTime(2023, 12, 17, 11, 15, 52, 319, DateTimeKind.Utc).AddTicks(3612), null, null },
                    { "en", true, "English", new DateTime(2023, 12, 17, 11, 15, 52, 319, DateTimeKind.Utc).AddTicks(3615), null, null }
                });

            migrationBuilder.InsertData(
                table: "categories_details",
                columns: new[] { "category_name", "language_code", "description", "name", "translated_name", "created_at", "deleted_at", "updated_at" },
                values: new object[,]
                {
                    { "MEN", "ar", "الوصف رجالي", null, "رجالي", new DateTime(2023, 12, 17, 11, 15, 52, 324, DateTimeKind.Utc).AddTicks(5731), null, null },
                    { "WOMEN", "ar", "نسائي الوصف", null, "نسائي", new DateTime(2023, 12, 17, 11, 15, 52, 324, DateTimeKind.Utc).AddTicks(5734), null, null },
                    { "MEN", "en", "Men Description", null, "Men", new DateTime(2023, 12, 17, 11, 15, 52, 324, DateTimeKind.Utc).AddTicks(5733), null, null },
                    { "WOMEN", "en", "Women Description", null, "Men", new DateTime(2023, 12, 17, 11, 15, 52, 324, DateTimeKind.Utc).AddTicks(5735), null, null }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "sku", "activation", "category_name", "supplier_identity", "created_at", "deleted_at", "updated_at", "cost_price", "discount", "is_discounted", "selling_price", "available_stock", "reserved_stock", "total_stock" },
                values: new object[,]
                {
                    { "1", true, "MEN", 0, new DateTime(2023, 12, 17, 11, 15, 52, 328, DateTimeKind.Utc).AddTicks(5705), null, null, 60.0, 15.0, true, 100.0, 800, 200, 1000 },
                    { "2", true, "WOMEN", 0, new DateTime(2023, 12, 17, 11, 15, 52, 328, DateTimeKind.Utc).AddTicks(5709), null, null, 140.0, 20.0, false, 200.0, 1500, 500, 2000 }
                });

            migrationBuilder.InsertData(
                table: "product_details",
                columns: new[] { "language_code", "sku", "description", "name", "product_sku", "created_at", "deleted_at", "updated_at" },
                values: new object[,]
                {
                    { "ar", "1", "الوصف 1", "الاسم 1", null, new DateTime(2023, 12, 17, 11, 15, 52, 331, DateTimeKind.Utc).AddTicks(5351), null, null },
                    { "ar", "2", "الوصف 2", "الاسم 2", null, new DateTime(2023, 12, 17, 11, 15, 52, 331, DateTimeKind.Utc).AddTicks(5355), null, null },
                    { "en", "1", "Shirt Description", "Shirt", null, new DateTime(2023, 12, 17, 11, 15, 52, 331, DateTimeKind.Utc).AddTicks(5354), null, null },
                    { "en", "2", "T-Shirt Description", "T-Shirt", null, new DateTime(2023, 12, 17, 11, 15, 52, 331, DateTimeKind.Utc).AddTicks(5355), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "ix_categories_parent_name",
                table: "categories",
                column: "parent_name");

            migrationBuilder.CreateIndex(
                name: "ix_categories_details_category_name",
                table: "categories_details",
                column: "category_name");

            migrationBuilder.CreateIndex(
                name: "ix_categories_details_name",
                table: "categories_details",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_product_details_product_sku",
                table: "product_details",
                column: "product_sku");

            migrationBuilder.CreateIndex(
                name: "ix_product_details_sku",
                table: "product_details",
                column: "sku");

            migrationBuilder.CreateIndex(
                name: "ix_products_category_name",
                table: "products",
                column: "category_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories_details");

            migrationBuilder.DropTable(
                name: "product_details");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
