using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopHoaTuoi.Models
{
    public class OrderModelView
    {
        [Required(ErrorMessage = "Vui lòng nhập tên khách hàng")]
        public string tenkh { get; set; }
        [Phone]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string sdt { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string diachi { get; set; }
        public string email { get; set; }
        public int thanhtoan { get; set; }
    }
}