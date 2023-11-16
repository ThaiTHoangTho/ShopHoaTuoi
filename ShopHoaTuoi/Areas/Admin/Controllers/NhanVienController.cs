using PagedList;
using ShopHoaTuoi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopHoaTuoi.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: Admin/NhanVien
        private ShopHoaTuoiEntities db = new ShopHoaTuoiEntities();
        // GET: Admin/Products
        public ActionResult Index()
        {
           var items=db.NHANVIENs;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(NHANVIEN model)
        {
            if (ModelState.IsValid)
            {
                db.NHANVIENs.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);

        }
        public ActionResult Edit(int id)
        {
            var item = db.NHANVIENs.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NHANVIEN model)
        {
            if (ModelState.IsValid)
            {

                db.NHANVIENs.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.NHANVIENs.Find(id);
            if (item != null)
            {
                db.NHANVIENs.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
    }
}