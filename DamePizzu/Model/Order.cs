using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DamePizzu.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string Food { get; set; }

        public double TotalPrice { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public bool Favourite { get; set; } = false;

        public List<OrderAccessories> OrderAccessories { get; set; }
    }
}