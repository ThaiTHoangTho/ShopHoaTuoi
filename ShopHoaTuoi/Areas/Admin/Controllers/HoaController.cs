using PagedList;
using ShopHoaTuoi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopHoaTuoi.Areas.Admin.Controllers
{
    public class HoaController : Controller
    {
        // GET: Admin/Hoa
       
        private ShopHoaTuoiEntities db = new ShopHoaTuoiEntities();
        public ActionResult Index(int? page)
        {
            IEnumerable<HOA> items = db.HOAs.OrderByDescending(x => x.mahoa);
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
        public ActionResult Add()
        {
            ViewBag.LoaiHoa = new SelectList(db.LOAIHOAs.ToList(), "maloai", "tenloai");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(HOA model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.LoaiHoa = new SelectList(db.LOAIHOAs.ToList(), "maloai", "tenloai");
                db.HOAs.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);

        }
        public ActionResult Edit(int id)
        {
            ViewBag.LoaiHoa = new SelectList(db.LOAIHOAs.ToList(), "maloai", "tenloai");
            var item = db.HOAs.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HOA model)
        {
            if (ModelState.IsValid)
            {
                db.HOAs.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.HOAs.Find(id);
            if (item != null)
            {
                db.HOAs.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsHot(int id)
        {
            var item = db.HOAs.Find(id);
            if (item != null)
            {
                item.banchay = !item.banchay;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, IsHot = item.banchay });
            }

            return Json(new { success = false });
        }

    }
}