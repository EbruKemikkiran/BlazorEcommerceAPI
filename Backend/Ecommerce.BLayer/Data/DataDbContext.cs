

using Microsoft.EntityFrameworkCore;

namespace Ecommerce.BLayer.Data
{
    public class DataDbContext : DbContext
    {

        //public DataDbContext()
        //{
            
        //}

        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Stats> Stats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductVariant>()
                .HasKey(p => new { p.ProductId, p.EditionId });

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Books", Url = "books", Icon = "book" },
                new Category { Id = 2, Name = "Electronics", Url = "electronics", Icon = "camera-slr" },
                new Category { Id = 3, Name = "Video Games", Url = "video-games", Icon = "aperture" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "Oh, the Places You'll Go!",
                    Description = "It is a book written and illustrated by children's author Dr. Seuss.A young boy, referred to simply as \"you\", initiates the action of the story; the presence of a main character helps readers to identify with the book.",
                    Image = "https://upload.wikimedia.org/wikipedia/en/0/07/Oh%2C_the_Places_You%27ll_Go.jpg",
                    DateCreated = new DateTime(2021, 1, 1)
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 1,
                    Title = "The Elephant Vanishes",
                    Description = "The Elephant Vanishes is a collection of 17 short stories by Japanese author Haruki Murakami. The stories were written between 1980 and 1991,[1] and published in Japan in various magazines, then collections. The stories mesh normality with surrealism, and focus on painful issues involving loss, destruction, confusion and loneliness.",
                    Image = "https://upload.wikimedia.org/wikipedia/en/1/11/Haruki_murakami_elephant_9780679750536.jpg",
                    DateCreated = new DateTime(2021, 1, 1)
                },
                new Product
                {
                    Id = 3,
                    CategoryId = 1,
                    Title = "Nutuk",
                    Description = "Nutuk: The speech covered the events between the start of the Turkish War of Independence on 19 May 1919, and the foundation of the Republic of Turkey, in 1923. Atatürk designated these concepts as the 'most precious treasures' of Turkish people, the 'foundations' of their new state, and the preconditions of their future 'existence' in his speech.",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ec/Nutuk.jpg/800px-Nutuk.jpg",
                    DateCreated = new DateTime(2021, 1, 1)
                },
                new Product
                {
                    Id = 4,
                    CategoryId = 2,
                    Title = "Dell G Series",
                    Description = "The Dell G Series is the successor to the Dell Inspiron Gaming Series. This series is positioned below Alienware and competes with Lenovo's Legion, Acer's Nitro and Predator Helios, HP's Omen and Pavilion Power laptops.",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dc/Dell_G5_Series_Desktop.jpg/300px-Dell_G5_Series_Desktop.jpg",
                    DateCreated = new DateTime(2021, 1, 1)
                },
                new Product
                {
                    Id = 5,
                    CategoryId = 2,
                    Title = "GeForce 900 series",
                    Description = "The GeForce 900 series is a family of graphics processing units developed by Nvidi.",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8a/GTX980tiFE.jpg/1280px-GTX980tiFE.jpg",
                    DateCreated = new DateTime(2021, 1, 1)
                },
                new Product
                {
                    Id = 6,
                    CategoryId = 2,
                    Title = "The Quadro RTX",
                    Description = "The Quadro RTX series is based on the Turing microarchitecture, and features real-time raytracing.",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/1/11/QuadroRTX4000.jpg",
                    DateCreated = new DateTime(2021, 1, 1)
                },
                new Product
                {
                    Id = 7,
                    CategoryId = 3,
                    Title = "Sins of a Solar Empire",
                    Description = "It is a real-time strategy (RTS) game that incorporates some elements from 4X games; its makers describe it as \"RT4X\".",
                    Image = "https://upload.wikimedia.org/wikipedia/en/a/a4/Sins_of_a_Solar_Empire_cover.PNG",
                    DateCreated = new DateTime(2021, 1, 1)
                },
                new Product
                {
                    Id = 8,
                    CategoryId = 3,
                    Title = "Warhammer 40,000: Dawn of War",
                    Description = "Warhammer 40,000: Dawn of War is a military science fiction real-time strategy video game developed by Relic Entertainment and based on Games Workshop's tabletop wargame Warhammer 40,000. It was released by THQ on September 20, 2004 in North America and on September 24 in Europe.",
                    Image = "https://upload.wikimedia.org/wikipedia/en/9/9f/Dawn_of_War_box_art.jpg",
                    DateCreated = new DateTime(2021, 1, 1)
                },
                new Product
                {
                    Id = 9,
                    CategoryId = 3,
                    Title = "Warcraft III: Reign of Chaos",
                    Description = "Warcraft III: Reign of Chaos is a high fantasy real-time strategy computer video game developed and published by Blizzard Entertainment released in July 2002. It is the second sequel to Warcraft: Orcs & Humans, after Warcraft II: Tides of Darkness, the third game set in the Warcraft fictional universe, and the first to be rendered in three dimensions.",
                    Image = "https://upload.wikimedia.org/wikipedia/en/6/66/WarcraftIII.jpg",
                    DateCreated = new DateTime(2021, 1, 1)
                }
            );

            modelBuilder.Entity<Edition>().HasData(
                    new Edition { Id = 1, Name = "Default" },
                    new Edition { Id = 2, Name = "Paperback" },
                    new Edition { Id = 3, Name = "E-Book" },
                    new Edition { Id = 4, Name = "Audiobook" },
                    new Edition { Id = 5, Name = "PC" },
                    new Edition { Id = 6, Name = "PlayStation" },
                    new Edition { Id = 7, Name = "Xbox" }
                );

            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant
                {
                    ProductId = 1,
                    EditionId = 2,
                    Price = 9.99m,
                    OriginalPrice = 19.99m
                },
                new ProductVariant
                {
                    ProductId = 1,
                    EditionId = 3,
                    Price = 7.99m
                },
                new ProductVariant
                {
                    ProductId = 1,
                    EditionId = 4,
                    Price = 19.99m,
                    OriginalPrice = 29.99m
                },
                new ProductVariant
                {
                    ProductId = 2,
                    EditionId = 2,
                    Price = 7.99m,
                    OriginalPrice = 14.99m
                },
                new ProductVariant
                {
                    ProductId = 3,
                    EditionId = 2,
                    Price = 6.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    EditionId = 1,
                    Price = 166.66m,
                    OriginalPrice = 249.00m
                },
                new ProductVariant
                {
                    ProductId = 5,
                    EditionId = 1,
                    Price = 159.99m,
                    OriginalPrice = 299m
                },
                new ProductVariant
                {
                    ProductId = 6,
                    EditionId = 1,
                    Price = 73.74m,
                    OriginalPrice = 400m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    EditionId = 5,
                    Price = 19.99m,
                    OriginalPrice = 29.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    EditionId = 6,
                    Price = 69.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    EditionId = 7,
                    Price = 49.99m,
                    OriginalPrice = 59.99m
                },
                new ProductVariant
                {
                    ProductId = 8,
                    EditionId = 5,
                    Price = 9.99m,
                    OriginalPrice = 24.99m,
                },
                new ProductVariant
                {
                    ProductId = 9,
                    EditionId = 5,
                    Price = 14.99m
                }
            );
        }
    }
}

