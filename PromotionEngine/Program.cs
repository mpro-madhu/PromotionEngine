﻿using System;
using System.Collections.Generic;
using PromotionEngine.DomainObjects;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // SET UP PRODUCTS
            Product A = new Product() { Name = "A", UnitPrice = 50};
            Product B = new Product() { Name = "B", UnitPrice = 30 };
            Product C = new Product() { Name = "C", UnitPrice = 20 };
            Product D = new Product() { Name = "D", UnitPrice = 15 };

            // SET UP Promotions

            //Coupon for Product A
            ProductCouponItem couponAItem = new ProductCouponItem() { CouponProduct = A, CouponUnits = 3 };
            ProductCoupon couponA = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponAItem }, CouponAmount = 130 };


            //Coupon for Product B
            ProductCouponItem couponBItem = new ProductCouponItem() { CouponProduct = B, CouponUnits = 2 };
            ProductCoupon couponB = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponBItem }, CouponAmount = 45 };

            //Coupon for Product B
            ProductCouponItem couponCItem = new ProductCouponItem() { CouponProduct = C, CouponUnits = 1 };
            ProductCouponItem couponDItem = new ProductCouponItem() { CouponProduct = D, CouponUnits = 1 };
            ProductCoupon couponCD = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponCItem,couponDItem }, CouponAmount = 45 };

            // Promotion Engine
            PromoEngine promoEngine = new PromoEngine(new List<ProductCoupon>() { couponA, couponB, couponCD });


            // Test 1
            Order order1 = new Order();
            List<OrderItem> items = new List<OrderItem>();
            items.Add(new OrderItem() { ProductItem = A, Quantity = 1 });
            items.Add(new OrderItem() { ProductItem = B, Quantity = 1 });
            items.Add(new OrderItem() { ProductItem = C, Quantity = 1 });
            order1.OrderItems = items;
            int order1Price = promoEngine.GetOrderTotal(order1);
            Console.WriteLine(100 == order1Price);


            // Test 2
            Order order2 = new Order();
            items.Clear();
            items.Add(new OrderItem() { ProductItem = A, Quantity = 5 });
            items.Add(new OrderItem() { ProductItem = B, Quantity = 5 });
            items.Add(new OrderItem() { ProductItem = C, Quantity = 1 });
            order2.OrderItems = items;
            int order2Price = promoEngine.GetOrderTotal(order1);
            Console.WriteLine(370 == order2Price);


            Console.Read();
        }
    }
}
