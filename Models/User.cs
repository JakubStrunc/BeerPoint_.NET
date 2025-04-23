
using System.ComponentModel.DataAnnotations;

namespace PNET_semestralka_blazor_app.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(45)]
        public string UzivatelskeJmeno { get; set; }

        [StringLength(45)]
        public string Email { get; set; }

        [StringLength(45)]
        public string Heslo { get; set; }

        
    }
    public class Seller : User
    {
        public ICollection<Product>? Products { get; set; }

        
    }

    public class Customer : User
    {

        public ICollection<SendingAddress>? ShippingDetails { get; set; }

        public ICollection<Order>? Orders { get; set; }


    }

}
