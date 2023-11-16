using PagedList;
using ShopHoaTuoi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopHoaTuoi.Controllers
{
    public class ProductController : Controller
    {
        private ShopHoaTuoiEntities db = new ShopHoaTuoiEntities();
        // GET: Products
        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<HOA> items = db.HOAs.OrderByDescending(x => x.giaban);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.tenhoa.ToLower().Trim().Contains(Searchtext.ToLower().Trim()) || x.tenhoa.Contains(Searchtext.ToLower().Trim()));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult ProductCategory(string tenloai, int id)
        {
            var item = db.HOAs.ToList();
            if (id > 0)
            {
                item = item.Where(x => x.maloai == id).ToList();
            }
            var cate = db.LOAIHOAs.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.tenloai;
            }
            ViewBag.CateId = id;
            return View(item);
        }
        public ActionResult Detail(int id)
        {
            var item = db.HOAs.Find(id);
            return View(item);
        }
        public ActionResult Partial_ItemsbyCategoryId()
        {
            var items = db.HOAs.ToList();
            return PartialView("_Partial_ItemsbyCategoryId", items);
        }
        
    }
}