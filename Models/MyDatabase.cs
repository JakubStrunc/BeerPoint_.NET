using PNET_semestralka_blazor_app.Data;
using PNET_semestralka_blazor_app.Models;
using Microsoft.EntityFrameworkCore;

namespace PNET_semestralka_blazor_app.Migrations
{
    public class MyDatabase
    {
        private readonly ApplicationDbContext _context;

        public MyDatabase(ApplicationDbContext context)
        {
            _context = context;
        }

        

        public List<Product> GetAllProducts()
        {
            return _context.Products.Include(p => p.Seller).ToList();
        }

        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            return _context.Orders
                .Include(o => o.OrderItems)         // načíst položky objednávky
                .ThenInclude(oi => oi.Product)  // a jejich produkty
                .Where(o => o.CustomerId == customerId && o.Stav != "Košík")
                .ToList();
        }

        public Order GetCartByCustomerId(int customerId )
        {
            var cart = _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.CustomerId == customerId && o.Stav == "Košík")
                .ToList();

            if (cart.Any())
            {
                return cart.First();
            }
            else
            {
                var newCart = new Order
                {
                    CustomerId = customerId,
                    Stav = "Košík",
                    OrderItems = new List<OrderItem>()
                };
                _context.Orders.Add(newCart);
                _context.SaveChanges();

                return newCart;
            }
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.OrderItems)         // načíst položky objednávky
                .ThenInclude(oi => oi.Product)  // a jejich produkty
                .Where(o => o.Stav != "Košík")
                .ToList();
        }

    }
}

