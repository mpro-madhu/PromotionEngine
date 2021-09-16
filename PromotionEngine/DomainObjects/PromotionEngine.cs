using System;
using System.Collections.Generic;
namespace PromotionEngine.DomainObjects
{
    public class PromoEngine
    {
        List<ProductCoupon> _coupons = null;
        public PromoEngine( List<ProductCoupon> productCoupons)
        {
            _coupons = productCoupons;

        }

        public List<ProductCoupon> ProductCoupons { get; }

        public int GetOrderTotal(Order customerOrder)
        {
            int total = 0;

            if (_coupons == null || _coupons.Count == 0)
            {
                // No PROMO Coupons 
                foreach (OrderItem item in customerOrder.OrderItems)
                {
                    total = total + (item.Quantity * item.ProductItem.UnitPrice);
                }
            }
            else
            {
                foreach (OrderItem item in customerOrder.OrderItems)
                {
                    total = total + GetPromoPrice(item);
                }

            }

            return total;
        }

        public int GetPromoPrice(OrderItem item)
        {
            
            foreach (ProductCoupon pc in _coupons)
            {
                ProductCouponItem productCouponItem = pc.CouponItems.Find(ci => ci.CouponProduct.Name == item.ProductItem.Name);
                if (productCouponItem != null && pc.CouponItems.Count == 1 )
                {
                    int couponUnitCount = item.Quantity / productCouponItem.CouponUnits;
                    int nonCouponUnitCount = item.Quantity % productCouponItem.CouponUnits;
                    return ((couponUnitCount * pc.CouponAmount) + (nonCouponUnitCount * item.ProductItem.UnitPrice)); 

                }

            }
            return (item.Quantity * item.ProductItem.UnitPrice);
        }

    }
}
