using ShopHoaTuoi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopHoaTuoi.Areas.Admin.Controllers
{
    public class LoaiHoaController : Controller
    {
        private ShopHoaTuoiEntities db = new ShopHoaTuoiEntities();
        // GET: Admin/LoaiHoa
        public ActionResult Index()
        {
            var item = db.LOAIHOAs;
            return View(item);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(LOAIHOA loaihoa)
        {
            if (ModelState.IsValid)
            {
                db.LOAIHOAs.Add(loaihoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var item = db.LOAIHOAs.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LOAIHOA model)
        {
            if (ModelState.IsValid)
            {
                db.LOAIHOAs.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.LOAIHOAs.Find(id);
            if (item != null)
            {
                //var DeleteItem = db.Categories.Attach(item);
                db.LOAIHOAs.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}