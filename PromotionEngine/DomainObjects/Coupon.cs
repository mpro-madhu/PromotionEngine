using System;
namespace PromotionEngine.DomainObjects
{
    public class Coupon
    {
        public Coupon()
        {
        }

        public int Units { get; set; }
        public int CouponPrice { get; set; }
    }
}
