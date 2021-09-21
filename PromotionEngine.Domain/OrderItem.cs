using System;
namespace PromotionEngine.Domain
{
    public class OrderItem
    {
        public OrderItem()
        {
        }

        public int Quantity { set; get; }
        public Product ProductItem { set; get; }
    }
}
