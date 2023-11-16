using ShopHoaTuoi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopHoaTuoi.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: Admin/KhachHang
        private ShopHoaTuoiEntities db = new ShopHoaTuoiEntities();
        // GET: Admin/Products
        public ActionResult Index()
        {
            var items = db.KHACHHANGs;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(KHACHHANG model)
        {
            if (ModelState.IsValid)
            {
                db.KHACHHANGs.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);

        }
        public ActionResult Edit(int id)
        {
            var item = db.KHACHHANGs.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KHACHHANG model)
        {
            if (ModelState.IsValid)
            {

                db.KHACHHANGs.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.KHACHHANGs.Find(id);
            if (item != null)
            {
                db.KHACHHANGs.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
    }
}