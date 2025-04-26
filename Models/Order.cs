﻿using PNET_semestralka_blazor_app.Models;
using System.ComponentModel.DataAnnotations;

namespace PNET_semestralka_blazor_app.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [StringLength(45)]
        public string? Jmeno { get; set; }

        [StringLength(45)]
        public string? Prijmeni { get; set; }

        [StringLength(45)]
        public string? Ulice { get; set; }

        public int? PopisneCislo { get; set; }

        public int? OrientacniCislo { get; set; }
        public int? Psc { get; set; }

        [StringLength(45)]
        public string? Mesto { get; set; }

        [StringLength(20)]
        public string? Stav { get; set; }

		public ICollection<OrderItem> OrderItems { get; set; }

        public string CustomerId { get; set; }
        public ApplicationUser? Customer { get; set; }

        
    }
}





