using Microsoft.EntityFrameworkCore.Migrations;

namespace Lib.Data.Migrations
{
    public partial class InitialSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, 0, null, "Adidas is a multinational firm which was founded in 1948. The firs specialized in designing and manufacturing of sports clothing and accessories.", false, "Adidas", 0, null });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, 0, null, "It was founded in 1964 as Blue Ribbon Sports by Bill Bowerman, a track-and-field coach at the University of Oregon, and his former student Phil Knight. They opened their first retail outlet in 1966 and launched the Nike brand shoe in 1972.", false, "Nike", 0, null });

            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, "HN", 0, null, false, "YONG", 0, null });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name", "Price", "Quanity", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, 1, 0, null, "Timeless appeal. Effortless style. Everyday versatility. For over 50 years and counting, adidas Stan Smith Shoes have continued to hold their place as an icon. This pair shows off a fresh redesign as part of adidas' commitment to use only recycled polyester by 2024. Plus, they have an outsole made from rubber waste add to the classic style. This product is made with Primegreen, a series of high - performance recycled materials. 50 % of upper is recycled content. No virgin polyester.", false, "STAN SMITH", 2300000m, 100, 0, null });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name", "Price", "Quanity", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, 2, 0, null, "The Nike Rise 365 Top delivers versatile performance for everyday running. Designed for lightweight mobility, the top features soft fabric with increased ventilation where you need it most.", false, "Nike Rise 365 BRS", 1279000m, 100, 0, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
