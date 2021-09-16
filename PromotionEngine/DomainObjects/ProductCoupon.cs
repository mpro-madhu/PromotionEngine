using System;
using System.Collections.Generic;
namespace PromotionEngine.DomainObjects
{
    public class ProductCoupon
    {
        public ProductCoupon()
        {
        }

        public List<ProductCouponItem> CouponItems { get; set; }


        public int CouponAmount { set; get; }
    }
}
