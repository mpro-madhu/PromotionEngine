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
                // With PROMO codes
                for (int i = 0; i < customerOrder.OrderItems.Count; i++)
                {
                    total = total + GetPromoPrice(customerOrder.OrderItems[i], customerOrder);
                }
                /*
                foreach (OrderItem item in customerOrder.OrderItems)
                {
                    total = total + GetPromoPrice(item,customerOrder);
                }
                */

            }

            return total;
        }

       

        public int GetPromoPrice(OrderItem item,Order customerOrder)
        {
            
            foreach (ProductCoupon pc in _coupons)
            {
                ProductCouponItem productCouponItem = pc.CouponItems.Find(ci => ci.CouponProduct.Name == item.ProductItem.Name);
                if (productCouponItem != null)   
                {
                    
                    if (pc.CouponItems.Count == 1)
                    {
                        // Simple PROMO codes.
                        int couponUnitCount = item.Quantity / productCouponItem.CouponUnits;
                        int nonCouponUnitCount = item.Quantity % productCouponItem.CouponUnits;
                        return ((couponUnitCount * pc.CouponAmount) + (nonCouponUnitCount * item.ProductItem.UnitPrice));
                    }
                    else if (pc.CouponItems.Count > 1)
                    {
                        // Hybrid promo codes.


                        Dictionary<ProductCouponItem, OrderItem> counponOrderUnits = new Dictionary<ProductCouponItem, OrderItem>();

                        foreach (ProductCouponItem pcItem in pc.CouponItems)
                        {
                            OrderItem orderItem = customerOrder.OrderItems.Find(p => p.ProductItem.Name == pcItem.CouponProduct.Name);
                            if (orderItem == null)
                            {
                                return item.Quantity * item.ProductItem.UnitPrice;
                            }
                            else
                            {
                                counponOrderUnits.Add(pcItem, item);
                                customerOrder.OrderItems.Remove(item);
                            }
                        }
                        if (counponOrderUnits.Count > 0)
                            return pc.CouponAmount;

                    }

                }
                

            }
            return (item.Quantity * item.ProductItem.UnitPrice);
        }

    }
}
