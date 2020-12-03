using System;
namespace DamePizzu.Model
{
    public class OrderAccessories
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal PriceOneItem { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
