using EShop.Infra.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infra.Domain
{
    public class EshopContext : DbContext
    {
        public EshopContext(DbContextOptions<EshopContext> options)
            : base(options)
        {

        }

        public DbSet<EShop.Infra.Domain.Entity.Product> Products { get; set; }

        public DbSet<ProductBrand> ProductBrands { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductBrand>().HasData(
                    new ProductBrand(1, "Microsoft"),
                    new ProductBrand(2, "Apple"),
                    new ProductBrand(3, "Dell"),
                    new ProductBrand(4, "Samsung"),
                    new ProductBrand(5, "OnePlus"),
                    new ProductBrand(6, "iQOO")
                );

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType(1, "Laptop"),
                new ProductType(2, "Mobile"),
                new ProductType(3, "EarBud")
            );

            modelBuilder.Entity<EShop.Infra.Domain.Entity.Product>().HasData(
                new EShop.Infra.Domain.Entity.Product(1, "Dell Inspiron 5518", 71000, 51, 1, 3, "16Gb Ram, 512Gb Ssd, Windows 11 + Ms Office'21, Nvidia Mx450 2Gb, 15.6 Inches (39.62 Cms) 250 Nits Fhd, Platinum Silver, Fpr + Backlit Kb"),
                new EShop.Infra.Domain.Entity.Product(2, "Apple MacBook Pro Laptop", 149900, 11, 1, 2, "M2 chip: 33.74 cm (13.3-inch) Retina Display, 8GB RAM, 512GB SSD ​​​​​​​Storage, Touch Bar, Backlit Keyboard, FaceTime HD Camera; Silver"),
                new EShop.Infra.Domain.Entity.Product(3, "Samsung Galaxy M52 5G", 21999, 21, 2, 4, "(ICY Blue, 8GB RAM, 128GB Storage) Latest Snapdragon 778G 5G | sAMOLED 120Hz Display"),
                new EShop.Infra.Domain.Entity.Product(4, "Samsung Galaxy Z Fold4 5G", 154999, 11, 2, 4, "(Beige, 12GB RAM, 256GB Storage) with No Cost EMI/Additional Exchange Offers"),
                new EShop.Infra.Domain.Entity.Product(5, "OnePlus Buds Z2", 4999, 51, 3, 5, "Pearl White | Truly Wireless Earbuds | Active Noise Cancellation")
            );
        }
    }
}