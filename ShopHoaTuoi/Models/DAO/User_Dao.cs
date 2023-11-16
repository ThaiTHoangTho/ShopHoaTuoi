using ShopHoaTuoi.Controllers;
using ShopHoaTuoi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopHoaTuoi.Models.DAO
{
    public class User_Dao
    {
        ShopHoaTuoiEntities _db = null;
        public User_Dao()
        {
            _db = new ShopHoaTuoiEntities();
        }
        
    }
}