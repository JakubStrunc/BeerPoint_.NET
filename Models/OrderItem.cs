
using PNET_semestralka_blazor_app.Models;

namespace PNET_semestralka_blazor_app.Models
{
    public record OrderItem
    {
  
        public int Pocet { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }

}




