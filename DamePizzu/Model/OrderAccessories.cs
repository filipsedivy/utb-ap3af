using System;
using System.ComponentModel.DataAnnotations;

namespace DamePizzu.Model
{
    public class OrderAccessories
    {
        [Key]
        public int OrderAccessorieId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public double PriceOneItem { get; set; }

        public double TotalPrice { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
