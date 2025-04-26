
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PNET_semestralka_blazor_app.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        // Pokud je zákazník
        public ICollection<Order>? Orders { get; set; }
        public ICollection<SendingAddress>? SendingAddresses { get; set; }

        // Pokud je prodejce
        public ICollection<Product>? Products { get; set; }
    }
}
