using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopHoaTuoi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            routes.MapRoute(
           name: "ProductCategory",
           url: "danh-muc-san-pham/{id}",
           defaults: new { controller = "Product", action = "ProductCategory", id = UrlParameter.Optional },
           namespaces: new[] { "ShopHoaTuoi.Controllers" }
       );/*
            routes.MapRoute(
               name: "ProductDetails",
               url: "chi-tiet/-p{id}",
               defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
               namespaces: new[] { "Shop_HighKatFlower.Controllers" }
           );*/
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ShopHoaTuoi.Controllers" }
            );

            routes.MapRoute(
           name: "Intro",
           url: "gioi-thieu",
           defaults: new { controller = "Gioithieu", action = "Index", alias = UrlParameter.Optional },
           namespaces: new[] { "ShopHoaTuoi.Controllers" }
       );
            routes.MapRoute(
              name: "Contact",
              url: "lien-he",
              defaults: new { controller = "Contact", action = "Index", alias = UrlParameter.Optional },
              namespaces: new[] { "ShopHoaTuoi.Controllers" }
          );
            routes.MapRoute(
             name: "Checkout",
             url: "thanh-toan",
             defaults: new { controller = "Shoppingcart", action = "Checkout", alias = UrlParameter.Optional },
             namespaces: new[] { "ShopHoaTuoi.Controllers" }
         );
        }
    }
}
