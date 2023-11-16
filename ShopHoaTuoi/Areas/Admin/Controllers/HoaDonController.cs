using PagedList;
using ShopHoaTuoi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopHoaTuoi.Areas.Admin.Controllers
{
    public class HoaDonController : Controller
    {
        private ShopHoaTuoiEntities db = new ShopHoaTuoiEntities();
        // GET: Admin/Order
        public ActionResult Index(int? page)
        {
            var query = from o in db.HOADONs
                        join od in db.CTHDs
                        on o.mahd equals od.mahd
                        join p in db.KHACHHANGs
                        on o.makh equals p.makh
                        select new
                        {
                            ngaylap = o.ngaylap,
                            tenkh = p.tenkh,
                            sdt = p.sdt
                        };
            var items = db.HOADONs.OrderByDescending(x => x.ngaylap).ToList();
            if (items == null)
            {
                page = 1;
            }
            var pageIndex = page ?? 1;
            var pageSize = 5;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = pageIndex;
            return View(items.ToPagedList(pageIndex, pageSize));
        }
        public ActionResult Detail(int id)
        {
            var item = db.HOADONs.Find(id);
            return View(item);

        }
        public ActionResult Partial_ProductDetail(int id)
        {
            var items = db.CTHDs.Where(x => x.mahd == id).ToList();
            return PartialView(items);
        }
        [HttpPost]
        public ActionResult UpdateStatus(int id, int status)
        {
            var item = db.HOADONs.Find(id);
            if (item != null)
            {
                db.HOADONs.Attach(item);
                //item. = status;
                //db.Entry(item).Property(x => x.TypePayment).IsModified = true;
                db.SaveChanges();
                return Json(new { message = "Success", Success = true });
            }
            return Json(new { message = "Unsuccess", Success = false });
        }
    }
}