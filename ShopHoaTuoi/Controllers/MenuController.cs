using ShopHoaTuoi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopHoaTuoi.Controllers
{
    public class MenuController : Controller
    {
        private ShopHoaTuoiEntities db = new ShopHoaTuoiEntities();

        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuProductCategory()
        {
            var items = db.LOAIHOAs.ToList();
            return PartialView("_MenuProductCategory", items);
        }

        public ActionResult MenuArrivals()
        {
            var a = db.LOAIHOAs.ToList();
            return PartialView("_MenuArrivals", a);
        }
        public ActionResult MenuLeft(int? id)
        {
            if (id != null)
            {
                ViewBag.CateId = id;
            }
            var items = db.LOAIHOAs;
            return PartialView("_MenuLeft", items);
        }
    }
}