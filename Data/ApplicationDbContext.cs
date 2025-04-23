
using Microsoft.EntityFrameworkCore;
using PNET_semestralka_blazor_app.Models;


namespace PNET_semestralka_blazor_app.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<SendingAddress> SendingAddress { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // [Asociace] Produkt patří prodejci (1:N)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Seller)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SellerId);

            // [Agregace] Doručovací adresa patří zákazníkovi (1:N)
            modelBuilder.Entity<SendingAddress>()
                .HasOne(sd => sd.Customer)
                .WithMany(c => c.ShippingDetails)
                .HasForeignKey(sd => sd.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // [Asociace] Objednávka patří zákazníkovi (1:N)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            // [Složený klíč] OrderItem: unikátní kombinace objednávka-produkt
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId });

            // [Agregace] Objednávka agreguje položky (OrderItem)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // Když smažu objednávku, zmizí i položky

            // [Asociace] Položka odkazuje na produkt
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.NoAction); // Produkt nemaže položky objednávek

        }
        public DbSet<PNET_semestralka_blazor_app.Models.Customer> Customer { get; set; } = default!;
    }
}




