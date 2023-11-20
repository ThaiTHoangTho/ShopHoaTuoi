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
        public ActionResult Partial_ProductsHot()
        {
            var items = db.HOAs.Where(p => p.banchay == true).Take(12).ToList();
            return PartialView("_Partial_ProductsHot", items);
        }
        public ActionResult Search(string keyword)
        {
            // Lấy danh sách sản phẩm từ cơ sở dữ liệu
            var products = db.HOAs.Where(x => x.tenhoa.Contains(keyword)).ToList();

            // Trả về danh sách sản phẩm
            return View(products);
        }
    }
}