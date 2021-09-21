using System;
using System.Collections.Generic;
namespace PromotionEngine.Domain
{
    public class Order
    {
        public Order()
        {
        }

        public List<OrderItem> OrderItems { get; set; }
    }
}
