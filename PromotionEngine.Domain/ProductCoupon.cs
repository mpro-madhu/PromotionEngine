using System;
using System.Collections.Generic;
namespace PromotionEngine.Domain
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
