using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnbWPF.Migrations
{
    public partial class addedextraseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Landlords",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 3, "Atal", "Burhani" });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AmountOfRooms", "City", "LandlordId", "PostalCode", "PricePerNight" },
                values: new object[,]
                {
                    { 3, "Rotterdamsestraat 21", 3, "Rotterdam", 2, "3011LL", 150 },
                    { 4, "Runmolenstraat 46", 4, "Almere", 2, "1333AR", 40 },
                    { 5, "De Wallen", 1, "Amsterdam", 2, "1063XO", 200 },
                    { 6, "Prinsengracht 123", 2, "Amsterdam", 1, "1015DK", 100 },
                    { 7, "Zeedijk 101", 3, "Amsterdam", 2, "1012AX", 120 },
                    { 8, "Keizersgracht 456", 5, "Amsterdam", 1, "1017EG", 200 },
                    { 9, "Groningerstraat 78", 4, "Groningen", 2, "9718PT", 80 }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AmountOfRooms", "City", "LandlordId", "PostalCode", "PricePerNight" },
                values: new object[] { 10, "Vrijthof 55", 6, "Maastricht", 3, "6211LE", 250 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Landlords",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
