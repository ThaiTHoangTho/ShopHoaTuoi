using ShopHoaTuoi.Models.DAO;
using ShopHoaTuoi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopHoaTuoi.Models.EF;
using ShopHoaTuoi.Common;

namespace ShopHoaTuoi.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new LogionDAO();
                var result = dao.Login(model.tendangnhap, model.matkhau);
                if (result == 1)
                {
                    var user = dao.getItems(model.tendangnhap);
                    var session = new NHANVIEN();
                    session.tendangnhap = user.tendangnhap;
                    session.manv = user.manv;
                    session.tennv = user.tennv;
                    session.email = user.email;
                    Session.Add(Hoa_funt.USER_SESSION, session);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng. Vui lòng kiểm tra lại!!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Tên đăng nhập không tồn tại. Vui lòng kiểm tra lại!!");
                }
            }
            return View("index");
        }

    }
}