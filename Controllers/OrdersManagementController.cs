using Microsoft.AspNetCore.Mvc;
using PNET_semestralka_blazor_app.Data;
using PNET_semestralka_blazor_app.Models;
using Microsoft.EntityFrameworkCore;
using PNET_semestralka_blazor_app.Migrations;

namespace PNET_semestralka_blazor_app.Controllers
{
    public class OrdersManagementController : Controller
{
		private readonly ApplicationDbContext _context;

		public OrdersManagementController(ApplicationDbContext context)
        {
            _context = context;
        }

		// Vrátí všechny objednávky uživatele podle emailu
		public async Task<List<Order>> GetAllOrdersAsync()
		{
			return await _context.Orders
				.Include(o => o.OrderItems)
					.ThenInclude(oi => oi.Product)
				.Where(o => o.Stav != "Košík")
				.ToListAsync();
		}
		public async Task UpdateOrderStatusAsync(int orderId, string newStatus)
		{
			var order = await _context.Orders.FindAsync(orderId);

			if (order == null)
				throw new Exception("Objednávka nenalezena.");

			order.Stav = newStatus;

			await _context.SaveChangesAsync();
		}

	}
}
