using Microsoft.Ajax.Utilities;
using ShopHoaTuoi.Models.EF;
using ShopHoaTuoi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopHoaTuoi.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ShopHoaTuoiEntities db = new ShopHoaTuoiEntities();
       
        // GET: ShoppingCart

        public ActionResult Index()
        {

            GIOHANG cart = (GIOHANG)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                ViewBag.CheckCart = cart;
            }
            return View();
        }
        public ActionResult CheckOutSuccess()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            GIOHANG cart = (GIOHANG)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                ViewBag.CheckCart = cart;
            }
            return View();
        }
        public ActionResult Partial_CheckOut()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(OrderModelView orderView)
        {
            HOADON order = new HOADON();
            KHACHHANG kh = new KHACHHANG();
            //var code = new { Success = false, Code = -1, UrlVNPay = "", UrlMomo = "", MaDonHang = order.Code, SoTien = order.TotalAmount.ToString() };
            if (ModelState.IsValid)
            {
                GIOHANG cart = (GIOHANG)Session["Cart"];
                if (cart != null)
                {
                    kh.tenkh = orderView.tenkh;
                    kh.sdt = orderView.sdt;
                    kh.diachi = orderView.diachi;
                    kh.email = orderView.email;
                    db.KHACHHANGs.Add(kh);
                    cart.Items.ForEach(x => order.CTHDs.Add(new CTHD
                    {
                       
                        mahoa=x.mahoa,
                        soluong=x.soluong,
                        tongtien=x.tongtien
                        
                    }));
                    //order.= cart.Items.Sum(x => (x.giaban * x.soluong));
                    order.makh = kh.makh;
                    order.ngaylap = DateTime.Now;
                    order.thanhtoan = orderView.thanhtoan;
                    Random rd = new Random();
                    order.madonhang = "DH" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9);
                    
                    db.HOADONs.Add(order);
                    db.SaveChanges();
                    //send mail
                    var strSanPham = "";
                    var thanhtien = decimal.Zero;
                    var TongTien = decimal.Zero;
                    foreach (var sp in cart.Items)
                    {
                        strSanPham += "<tr>";
                        strSanPham += "<td>" + sp.tenhoa + "</td>";
                        strSanPham += "<td>" + sp.soluong + "</td>";
                        strSanPham += "<td>" + ShopHoaTuoi.Common.Common.FormatNumber(sp.tongtien, 0) + "</td>";
                        strSanPham += "</tr>";
                        thanhtien += sp.giaban * sp.soluong;
                    }
                    TongTien = thanhtien;
                    string contentCustomer = System.IO.File.ReadAllText(Server.MapPath("~/Content/send/send2.html"));
                    contentCustomer = contentCustomer.Replace("{{MaDon}}", order.madonhang);
                    contentCustomer = contentCustomer.Replace("{{SanPham}}", strSanPham);
                    contentCustomer = contentCustomer.Replace("{{NgayDat}}", DateTime.Now.ToString("dd/MM/yyyy"));
                    contentCustomer = contentCustomer.Replace("{{TenKhachHang}}", kh.tenkh);
                    contentCustomer = contentCustomer.Replace("{{Phone}}", kh.tenkh);
                    contentCustomer = contentCustomer.Replace("{{Email}}", orderView.email);
                    contentCustomer = contentCustomer.Replace("{{DiaChiNhanHang}}", kh.diachi);
                    contentCustomer = contentCustomer.Replace("{{ThanhTien}}", ShopHoaTuoi.Common.Common.FormatNumber(thanhtien, 0));
                    contentCustomer = contentCustomer.Replace("{{TongTien}}", ShopHoaTuoi.Common.Common.FormatNumber(TongTien, 0));
                    ShopHoaTuoi.Common.Common.SendMail("HighKat_FLower", "Đơn đặt hàng #" + order.madonhang, contentCustomer.ToString(), orderView.email);
                }
            }
            return RedirectToAction("CheckOutSuccess");

        }
        public ActionResult Partial_Item_Pay()
        {
            GIOHANG cart = (GIOHANG)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }
        public ActionResult Partial_Item_Cart()
        {
            GIOHANG cart = (GIOHANG)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }
        
        [HttpPost]
        public ActionResult Addtocart(int id, int quantity)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };
            var checkProduct = db.HOAs.FirstOrDefault(x => x.mahoa == id);
            if (checkProduct != null)
            {
                GIOHANG cart = (GIOHANG)Session["Cart"];
                if (cart == null)
                {
                    cart = new GIOHANG();
                }
                CTGH shoppingcart = new CTGH
                {
                    mahoa = checkProduct.mahoa,
                    tenhoa = checkProduct.tenhoa,
                    soluong = quantity,
                    anh = checkProduct.anh,
                    giaban = (decimal)checkProduct.giaban

                };
                shoppingcart.tongtien = shoppingcart.soluong * shoppingcart.giaban;
                cart.Addtocart(shoppingcart, quantity);
                Session["Cart"] = cart;
                code = new { Success = true, msg = "Thêm vào giỏ hàng thành công", code = 1, Count = cart.Items.Count };
            }
            return Json(code);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };
            GIOHANG cart = (GIOHANG)Session["Cart"];
            if (cart != null)
            {
                var checkPro = cart.Items.FirstOrDefault(x => x.mahoa == id);
                if (checkPro != null)
                {
                    cart.Remove(id);
                    code = new { Success = true, msg = "", code = 1, Count = cart.Items.Count };

                }
            }
            return Json(code);
        }
        [HttpPost]
        public ActionResult DeleteAll()
        {
            GIOHANG cart = (GIOHANG)Session["Cart"];
            if (cart != null)
            {
                cart.Clear();
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        [HttpPost]
        public ActionResult Update(int id, int quantity)
        {
            GIOHANG cart = (GIOHANG)Session["Cart"];
            if (cart != null)
            {
                cart.UpdateQuanity(id, quantity);
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
    }
}