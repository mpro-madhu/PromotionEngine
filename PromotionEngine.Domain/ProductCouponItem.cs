using System;
namespace PromotionEngine.Domain
{
    public class ProductCouponItem
    {
        public ProductCouponItem()
        {
        }

        public int CouponUnits { set; get; }
        public Product CouponProduct { set; get; }
    }
}
