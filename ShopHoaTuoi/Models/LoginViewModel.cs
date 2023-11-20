using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopHoaTuoi.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập!!")]
        public string tendangnhap { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!!")]
        public string matkhau { get; set; }
        public bool Remember { get; set; }
    }
}