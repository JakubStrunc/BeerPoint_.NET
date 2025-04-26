using Microsoft.AspNetCore.Mvc;
using PNET_semestralka_blazor_app.Data;
using PNET_semestralka_blazor_app.Models;
using Microsoft.EntityFrameworkCore;
using PNET_semestralka_blazor_app.Migrations;

namespace PNET_semestralka_blazor_app.Controllers
{
    public class ProductsManagementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsManagementController(ApplicationDbContext contex)
        {
            _context = contex;
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
