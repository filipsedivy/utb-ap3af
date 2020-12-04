using System;
using System.Collections.Generic;

namespace DamePizzu.Model
{
    public class Order
    {
        public string Food { get; set; }

        public double TotalPrice { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public bool Favourite { get; set; } = false;

        public List<OrderAccessories> OrderAccessories { get; set; } = new List<OrderAccessories>();
    }
}