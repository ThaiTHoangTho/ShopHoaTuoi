using PagedList;
using ShopHoaTuoi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopHoaTuoi.Areas.Admin.Controllers
{
    public class KhoController : Controller
    {

        private ShopHoaTuoiEntities db = new ShopHoaTuoiEntities();
        // GET: Admin/Kho
        public ActionResult Index(int? page)
        {
            IEnumerable<KHO> items = db.KHOes.OrderByDescending(x => x.makho);
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
    }
}