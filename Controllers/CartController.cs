using Microsoft.AspNetCore.Mvc;
using PNET_semestralka_blazor_app.Data;
using PNET_semestralka_blazor_app.Models;
using Microsoft.EntityFrameworkCore;
using PNET_semestralka_blazor_app.Migrations;

namespace PNET_semestralka_blazor_app.Controllers
{
    public class CartController : Controller
    {

        private ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetCartAsync(string? userEmail)
        {

            // Najdi zákazníka podle emailu
            var customer = await _context.Users
                .Include(u => u.Orders)
                    .ThenInclude(o => o.OrderItems)
                        .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(u => u.Email == userEmail);

            // Najdi jeho aktivní "Košík" objednávku
            var cartOrder = customer.Orders
                .FirstOrDefault(o => o.Stav == "Košík");

            if (cartOrder == null)
            {
                cartOrder = new Order
                {
                    Stav = "Košík",
                    Customer = customer,
                    OrderItems = new List<OrderItem>()
                };

                _context.Orders.Add(cartOrder);
                await _context.SaveChangesAsync();
            }

            // Vrať položky z košíku
            return cartOrder;
        }
    }
    


    
}
