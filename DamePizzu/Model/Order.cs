using System;
using SQLite;

namespace DamePizzu.Model
{
    public class Order
    {
        public Order()
        {
            Created = DateTime.Now;
            Delivered = null;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Delivered { get; set; }
    }
}