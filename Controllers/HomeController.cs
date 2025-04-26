using Microsoft.AspNetCore.Mvc;
using PNET_semestralka_blazor_app.Data;
using PNET_semestralka_blazor_app.Models;
using Microsoft.EntityFrameworkCore;
using PNET_semestralka_blazor_app.Migrations;

namespace PNET_semestralka_blazor_app.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;


        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task AddToCartAsync(string? userEmail, Product product)
        {
            if (string.IsNullOrEmpty(userEmail))
                throw new ArgumentException("Email nesmí být prázdný.");

            if (product == null)
                throw new ArgumentNullException(nameof(product));

            // Najdi zákazníka podle emailu
            var customer = await _context.Users
                .Include(u => u.Orders)
                    .ThenInclude(o => o.OrderItems)
                        .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(u => u.Email == userEmail);

            if (customer == null)
                throw new Exception("Zákazník nenalezen.");

            // Najdi aktuální košík (stav "Košík")
            var cartOrder = customer.Orders.FirstOrDefault(o => o.Stav == "Košík");

            if (cartOrder == null)
            {
                // Pokud košík neexistuje, vytvoř nový
                cartOrder = new Order
                {
                    Stav = "Košík",
                    Customer = customer,
                    OrderItems = new List<OrderItem>()
                };

                _context.Orders.Add(cartOrder);
            }

            // Zkus najít existující položku v košíku
            var existingItem = cartOrder.OrderItems.FirstOrDefault(i => i.Product.Id == product.Id);

            if (existingItem != null)
            {
                // Produkt už v košíku je ➔ navýšíme počet
                existingItem.Pocet++;
            }
            else
            {
                // Produkt ještě v košíku není ➔ přidáme novou položku
                cartOrder.OrderItems.Add(new OrderItem
                {
                    Product = product,
                    Pocet = 1
                });
            }

            // Ulož změny do databáze
            await _context.SaveChangesAsync();
        }

    }
}
