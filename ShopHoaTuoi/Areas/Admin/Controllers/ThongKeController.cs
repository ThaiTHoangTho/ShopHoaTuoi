using ShopHoaTuoi.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopHoaTuoi.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        private ShopHoaTuoiEntities db = new ShopHoaTuoiEntities();
        // GET: Admin/ThongKe
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetStatistical(string fromDate, string toDate)
        {
            var query = from o in db.HOADONs
                        join od in db.CTHDs
                        on o.mahd equals od.mahd
                        join p in db.HOAs
                        on od.mahoa equals p.mahoa
                        join n in db.CT_PHIEUNHAPHOA 
                        on od.mahoa equals n.mahoa
                        select new
                        {
                            CreatedDate = o.ngaylap,
                            Quantity = od.soluong,
                            Price = p.giaban,
                            OriginalPrice = n.gianhap
                        };
            if (!string.IsNullOrEmpty(fromDate))
            {
                DateTime startDate = DateTime.ParseExact(fromDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.CreatedDate >= startDate);
            }
            if (!string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.ParseExact(toDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.CreatedDate < endDate);
            }

            var result = query.GroupBy(x => DbFunctions.TruncateTime(x.CreatedDate)).Select(x => new
            {
                Date = x.Key.Value,
                TotalBuy = x.Sum(y => y.Quantity * y.OriginalPrice),
                TotalSell = x.Sum(y => y.Quantity * y.Price),
            }).Select(x => new
            {
                Date = x.Date,
                DoanhThu = x.TotalSell,
                LoiNhuan = x.TotalSell - x.TotalBuy
            });
            return Json(new { Data = result }, JsonRequestBehavior.AllowGet);
        }
    }
}