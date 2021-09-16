using System;
namespace PromotionEngine.DomainObjects
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
