using System;
using Xunit;
using System.Collections.Generic;

using PromotionEngine.Domain;


namespace PromotionEngine.Tests
{
    public class PromotionEngineTests
    {
        [Fact]
        public void Product_No_Promotion_Applicable()
        {
            // SET UP PRODUCTS
            Product A = new Product() { Name = "A", UnitPrice = 50 };
            Product B = new Product() { Name = "B", UnitPrice = 30 };
            Product C = new Product() { Name = "C", UnitPrice = 20 };
            Product D = new Product() { Name = "D", UnitPrice = 15 };

            //Coupon for Product A
            ProductCouponItem couponAItem = new ProductCouponItem() { CouponProduct = A, CouponUnits = 3 };
            ProductCoupon couponA = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponAItem }, CouponAmount = 130 };


            //Coupon for Product B
            ProductCouponItem couponBItem = new ProductCouponItem() { CouponProduct = B, CouponUnits = 2 };
            ProductCoupon couponB = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponBItem }, CouponAmount = 45 };

            //Coupon for Product CD
            ProductCouponItem couponCItem = new ProductCouponItem() { CouponProduct = C, CouponUnits = 1 };
            ProductCouponItem couponDItem = new ProductCouponItem() { CouponProduct = D, CouponUnits = 1 };
            ProductCoupon couponCD = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponCItem, couponDItem }, CouponAmount = 30 };

            
            // Promotion Engine
            PromoEngine promoEngine = new PromoEngine(new List<ProductCoupon>() { couponA, couponB, couponCD });


            Order order = new Order();
            List<OrderItem> items = new List<OrderItem>();
            items.Add(new OrderItem() { ProductItem = A, Quantity = 1 });
            items.Add(new OrderItem() { ProductItem = B, Quantity = 1 });
            items.Add(new OrderItem() { ProductItem = C, Quantity = 1 });
            order.OrderItems = items;
            int order1Price = promoEngine.GetOrderTotal(order);
            
            Assert.Equal(100, order1Price);
        }


        [Fact]
        public void Product_Promotion_Applicable()
        {
            // SET UP PRODUCTS
            Product A = new Product() { Name = "A", UnitPrice = 50 };
            Product B = new Product() { Name = "B", UnitPrice = 30 };
            Product C = new Product() { Name = "C", UnitPrice = 20 };
            Product D = new Product() { Name = "D", UnitPrice = 15 };

            //Coupon for Product A
            ProductCouponItem couponAItem = new ProductCouponItem() { CouponProduct = A, CouponUnits = 3 };
            ProductCoupon couponA = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponAItem }, CouponAmount = 130 };


            //Coupon for Product B
            ProductCouponItem couponBItem = new ProductCouponItem() { CouponProduct = B, CouponUnits = 2 };
            ProductCoupon couponB = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponBItem }, CouponAmount = 45 };

            //Coupon for Product CD
            ProductCouponItem couponCItem = new ProductCouponItem() { CouponProduct = C, CouponUnits = 1 };
            ProductCouponItem couponDItem = new ProductCouponItem() { CouponProduct = D, CouponUnits = 1 };
            ProductCoupon couponCD = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponCItem, couponDItem }, CouponAmount = 30 };

           
            // Promotion Engine
            PromoEngine promoEngine = new PromoEngine(new List<ProductCoupon>() { couponA, couponB, couponCD });


            Order order2 = new Order();
            List<OrderItem> items = new List<OrderItem>();
            
            items.Add(new OrderItem() { ProductItem = A, Quantity = 5 });
            items.Add(new OrderItem() { ProductItem = B, Quantity = 5 });
            items.Add(new OrderItem() { ProductItem = C, Quantity = 1 });
            order2.OrderItems = items;
            int order2Price = promoEngine.GetOrderTotal(order2);
            
            

            Assert.Equal(370, order2Price);

        }


        [Fact]
        public void Product_Hybrid_Promotion_Applicable()
        {
            // SET UP PRODUCTS
            Product A = new Product() { Name = "A", UnitPrice = 50 };
            Product B = new Product() { Name = "B", UnitPrice = 30 };
            Product C = new Product() { Name = "C", UnitPrice = 20 };
            Product D = new Product() { Name = "D", UnitPrice = 15 };

            //Coupon for Product A
            ProductCouponItem couponAItem = new ProductCouponItem() { CouponProduct = A, CouponUnits = 3 };
            ProductCoupon couponA = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponAItem }, CouponAmount = 130 };


            //Coupon for Product B
            ProductCouponItem couponBItem = new ProductCouponItem() { CouponProduct = B, CouponUnits = 2 };
            ProductCoupon couponB = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponBItem }, CouponAmount = 45 };

            //Coupon for Product CD
            ProductCouponItem couponCItem = new ProductCouponItem() { CouponProduct = C, CouponUnits = 1 };
            ProductCouponItem couponDItem = new ProductCouponItem() { CouponProduct = D, CouponUnits = 1 };
            ProductCoupon couponCD = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponCItem, couponDItem }, CouponAmount = 30 };


            // Promotion Engine
            PromoEngine promoEngine = new PromoEngine(new List<ProductCoupon>() { couponA, couponB, couponCD });


            //Test 3
            Order order3 = new Order();
            List<OrderItem> items = new List<OrderItem>();
            items.Add(new OrderItem() { ProductItem = A, Quantity = 3 });
            items.Add(new OrderItem() { ProductItem = B, Quantity = 5 });
            items.Add(new OrderItem() { ProductItem = C, Quantity = 1 });
            items.Add(new OrderItem() { ProductItem = D, Quantity = 1 });
            order3.OrderItems = items;
            int order3Price = promoEngine.GetOrderTotal(order3);



            Assert.Equal(280, order3Price);

        }


        [Fact]
        public void Product_Hybrid_Promotion_Applicable_Variable_Combo_NotImplemented()
        {
            // SET UP PRODUCTS
            Product A = new Product() { Name = "A", UnitPrice = 50 };
            Product B = new Product() { Name = "B", UnitPrice = 30 };
            Product C = new Product() { Name = "C", UnitPrice = 20 };
            Product D = new Product() { Name = "D", UnitPrice = 15 };

            //Coupon for Product A
            ProductCouponItem couponAItem = new ProductCouponItem() { CouponProduct = A, CouponUnits = 3 };
            ProductCoupon couponA = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponAItem }, CouponAmount = 130 };


            //Coupon for Product B
            ProductCouponItem couponBItem = new ProductCouponItem() { CouponProduct = B, CouponUnits = 2 };
            ProductCoupon couponB = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponBItem }, CouponAmount = 45 };

            //Coupon for Product CD
            ProductCouponItem couponCItem = new ProductCouponItem() { CouponProduct = C, CouponUnits = 1 };
            ProductCouponItem couponDItem = new ProductCouponItem() { CouponProduct = D, CouponUnits = 1 };
            ProductCoupon couponCD = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponCItem, couponDItem }, CouponAmount = 30 };


            // Promotion Engine
            PromoEngine promoEngine = new PromoEngine(new List<ProductCoupon>() { couponA, couponB, couponCD });


            //Test 3
            Order order4 = new Order();
            List<OrderItem> items = new List<OrderItem>();
            items.Add(new OrderItem() { ProductItem = A, Quantity = 3 });
            items.Add(new OrderItem() { ProductItem = B, Quantity = 5 });
            items.Add(new OrderItem() { ProductItem = C, Quantity = 2 });
            items.Add(new OrderItem() { ProductItem = D, Quantity = 1 });
            order4.OrderItems = items;
            int order4Price = promoEngine.GetOrderTotal(order4);



            Assert.NotEqual(300, order4Price);

        }

        [Fact]
        public void Product_Hybrid_Promotion_Applicable_Multi_Slot_NotImplemented()
        {
            // SET UP PRODUCTS
            Product A = new Product() { Name = "A", UnitPrice = 50 };
            Product B = new Product() { Name = "B", UnitPrice = 30 };
            Product C = new Product() { Name = "C", UnitPrice = 20 };
            Product D = new Product() { Name = "D", UnitPrice = 15 };

            //Coupon for Product A
            ProductCouponItem couponAItem = new ProductCouponItem() { CouponProduct = A, CouponUnits = 3 };
            ProductCoupon couponA = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponAItem }, CouponAmount = 130 };


            //Coupon for Product B
            ProductCouponItem couponBItem = new ProductCouponItem() { CouponProduct = B, CouponUnits = 2 };
            ProductCoupon couponB = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponBItem }, CouponAmount = 45 };

            //Coupon for Product CD
            ProductCouponItem couponCItem = new ProductCouponItem() { CouponProduct = C, CouponUnits = 1 };
            ProductCouponItem couponDItem = new ProductCouponItem() { CouponProduct = D, CouponUnits = 1 };
            ProductCoupon couponCD = new ProductCoupon() { CouponItems = new System.Collections.Generic.List<ProductCouponItem>() { couponCItem, couponDItem }, CouponAmount = 30 };


            // Promotion Engine
            PromoEngine promoEngine = new PromoEngine(new List<ProductCoupon>() { couponA, couponB, couponCD });


            //Test 3
            Order order4 = new Order();
            List<OrderItem> items = new List<OrderItem>();
            items.Add(new OrderItem() { ProductItem = A, Quantity = 3 });
            items.Add(new OrderItem() { ProductItem = B, Quantity = 5 });
            items.Add(new OrderItem() { ProductItem = C, Quantity = 2 });
            items.Add(new OrderItem() { ProductItem = D, Quantity = 2 });
            order4.OrderItems = items;
            int order4Price = promoEngine.GetOrderTotal(order4);



            Assert.NotEqual(310, order4Price);
        }

    }
}
