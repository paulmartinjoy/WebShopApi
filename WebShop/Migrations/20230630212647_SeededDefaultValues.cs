using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebShop.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CareInformation", "CollectionType", "FitInformation", "MaterialInformation", "Name", "Season" },
                values: new object[,]
                {
                    { 1, "Gentle cycle 30 degrees, Chlorine bleach not possible", (short)10, "Fit: Regular fit, Length: 68cm", "Fabric: Cotton, Quality: soft", "Classic Poloshirt", "202305" },
                    { 2, "Gentle cycle 30 degrees, Chlorine bleach not possible", (short)15, "Fit: Slim fit, Rise: Mid rise", "Fabric: Denim, Quality: elastic", "Slim leg Jeans", "202301" },
                    { 3, "Gentle cycle 30 degrees, Chlorine bleach not possible", (short)20, "Fit: Regular fit, Length: 58cm", "Fabric: Woven, Quality: light, Filling: lightly padded", "Hooded Quilted Jacket", "202209" }
                });

            migrationBuilder.InsertData(
                table: "ColorInfos",
                columns: new[] { "Id", "ArticleId", "ColorCode", "ColorName", "Pictures" },
                values: new object[,]
                {
                    { 1, 1, "NVPOLO", "Navy", "[]" },
                    { 2, 2, "JNSBL", "Black", "[]" },
                    { 3, 3, "RDJCKT", "Red", "[]" }
                });

            migrationBuilder.InsertData(
                table: "VariantInfos",
                columns: new[] { "Id", "AvailableStock", "ColorInfoId", "EAN", "Price", "SizeOrLengthInfo" },
                values: new object[,]
                {
                    { 1, 15, 1, "2127495.5952.114/122", 13.99, "Size: medium, Length: 68cm, Sleeve length: short" },
                    { 2, 100, 2, "4556565.8552.114/150", 13.99, "Size: medium, Length: 68cm, Sleeve length: short" },
                    { 3, 21, 3, "256985.600.200/122", 13.99, "Size: medium, Length: 68cm, Sleeve length: long" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VariantInfos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VariantInfos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VariantInfos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ColorInfos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ColorInfos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ColorInfos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
