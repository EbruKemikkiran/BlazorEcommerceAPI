using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.BLayer.Migrations
{
    /// <inheritdoc />
    public partial class @base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Visits = table.Column<int>(type: "int", nullable: false),
                    LastVisit = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Views = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariant",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    EditionId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariant", x => new { x.ProductId, x.EditionId });
                    table.ForeignKey(
                        name: "FK_ProductVariant_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariant_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Icon", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "book", "Books", "books" },
                    { 2, "camera-slr", "Electronics", "electronics" },
                    { 3, "aperture", "Video Games", "video-games" }
                });

            migrationBuilder.InsertData(
                table: "Editions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Default" },
                    { 2, "Paperback" },
                    { 3, "E-Book" },
                    { 4, "Audiobook" },
                    { 5, "PC" },
                    { 6, "PlayStation" },
                    { 7, "Xbox" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateUpdated", "Description", "Image", "IsDeleted", "IsPublic", "Title", "Views" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "It is a book written and illustrated by children's author Dr. Seuss.A young boy, referred to simply as \"you\", initiates the action of the story; the presence of a main character helps readers to identify with the book.", "https://upload.wikimedia.org/wikipedia/en/0/07/Oh%2C_the_Places_You%27ll_Go.jpg", false, false, "Oh, the Places You'll Go!", 0 },
                    { 2, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Elephant Vanishes is a collection of 17 short stories by Japanese author Haruki Murakami. The stories were written between 1980 and 1991,[1] and published in Japan in various magazines, then collections. The stories mesh normality with surrealism, and focus on painful issues involving loss, destruction, confusion and loneliness.", "https://upload.wikimedia.org/wikipedia/en/1/11/Haruki_murakami_elephant_9780679750536.jpg", false, false, "The Elephant Vanishes", 0 },
                    { 3, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nutuk: The speech covered the events between the start of the Turkish War of Independence on 19 May 1919, and the foundation of the Republic of Turkey, in 1923. Atatürk designated these concepts as the 'most precious treasures' of Turkish people, the 'foundations' of their new state, and the preconditions of their future 'existence' in his speech.", "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ec/Nutuk.jpg/800px-Nutuk.jpg", false, false, "Nutuk", 0 },
                    { 4, 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Dell G Series is the successor to the Dell Inspiron Gaming Series. This series is positioned below Alienware and competes with Lenovo's Legion, Acer's Nitro and Predator Helios, HP's Omen and Pavilion Power laptops.", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dc/Dell_G5_Series_Desktop.jpg/300px-Dell_G5_Series_Desktop.jpg", false, false, "Dell G Series", 0 },
                    { 5, 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The GeForce 900 series is a family of graphics processing units developed by Nvidi.", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8a/GTX980tiFE.jpg/1280px-GTX980tiFE.jpg", false, false, "GeForce 900 series", 0 },
                    { 6, 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Quadro RTX series is based on the Turing microarchitecture, and features real-time raytracing.", "https://upload.wikimedia.org/wikipedia/commons/1/11/QuadroRTX4000.jpg", false, false, "The Quadro RTX", 0 },
                    { 7, 3, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "It is a real-time strategy (RTS) game that incorporates some elements from 4X games; its makers describe it as \"RT4X\".", "https://upload.wikimedia.org/wikipedia/en/a/a4/Sins_of_a_Solar_Empire_cover.PNG", false, false, "Sins of a Solar Empire", 0 },
                    { 8, 3, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Warhammer 40,000: Dawn of War is a military science fiction real-time strategy video game developed by Relic Entertainment and based on Games Workshop's tabletop wargame Warhammer 40,000. It was released by THQ on September 20, 2004 in North America and on September 24 in Europe.", "https://upload.wikimedia.org/wikipedia/en/9/9f/Dawn_of_War_box_art.jpg", false, false, "Warhammer 40,000: Dawn of War", 0 },
                    { 9, 3, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Warcraft III: Reign of Chaos is a high fantasy real-time strategy computer video game developed and published by Blizzard Entertainment released in July 2002. It is the second sequel to Warcraft: Orcs & Humans, after Warcraft II: Tides of Darkness, the third game set in the Warcraft fictional universe, and the first to be rendered in three dimensions.", "https://upload.wikimedia.org/wikipedia/en/6/66/WarcraftIII.jpg", false, false, "Warcraft III: Reign of Chaos", 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariant",
                columns: new[] { "EditionId", "ProductId", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { 2, 1, 19.99m, 9.99m },
                    { 3, 1, 0m, 7.99m },
                    { 4, 1, 29.99m, 19.99m },
                    { 2, 2, 14.99m, 7.99m },
                    { 2, 3, 0m, 6.99m },
                    { 1, 4, 249.00m, 166.66m },
                    { 1, 5, 299m, 159.99m },
                    { 1, 6, 400m, 73.74m },
                    { 5, 7, 29.99m, 19.99m },
                    { 6, 7, 0m, 69.99m },
                    { 7, 7, 59.99m, 49.99m },
                    { 5, 8, 24.99m, 9.99m },
                    { 5, 9, 0m, 14.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_EditionId",
                table: "ProductVariant",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductVariant");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Editions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
