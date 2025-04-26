using Microsoft.AspNetCore.Mvc;
using PNET_semestralka_blazor_app.Data;
using PNET_semestralka_blazor_app.Models;
using Microsoft.EntityFrameworkCore;
using PNET_semestralka_blazor_app.Migrations;

namespace PNET_semestralka_blazor_app.Controllers
{
    public class OrdersController
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Vrátí všechny objednávky uživatele podle emailu
        public async Task<List<Order>> GetOrdersAsync(string? userEmail)
        {

            var customer = await _context.Users
                .Include(u => u.Orders)
                    .ThenInclude(o => o.OrderItems)
                        .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(u => u.Email == userEmail);


            // Vrátíme všechny jeho objednávky
            return customer.Orders
                .Where(o => o.Stav != "Košík") 
                .ToList();
        }
    }
}
