using ShopHoaTuoi.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopHoaTuoi.Models
{
    public class LogionDAO
    {
        private ShopHoaTuoiEntities db = new ShopHoaTuoiEntities();

        public NHANVIEN AddNV(NHANVIEN nv)
        {
            db.NHANVIENs.Add(nv);
            db.SaveChanges();
            return nv;
        }
        public NHANVIEN getItems(string tendangnhap)
        {
            return db.NHANVIENs.FirstOrDefault(x => x.tendangnhap == tendangnhap);
        }
        public List<NHANVIEN> getList() { return db.NHANVIENs.ToList(); }
     /*   public NHANVIEN Update(NHANVIEN nv)
        {
            var us = db.NHANVIENs.FirstOrDefault(x => x.tennv == nv.Id);
            us.Password = user.Password;
            us.HoTen = user.HoTen;
            us.SDT = user.SDT;
            us.DiaChi = user.DiaChi;
            us.Email = user.Email;
            db.SaveChanges();
            return us;

        }*/
        public int Login(string tendangnhap, string password)
        {
            var user = db.NHANVIENs.FirstOrDefault(x => x.tendangnhap == tendangnhap);
            if (user == null)
            {
                return -2;//email không tồn tại
            }
            else
            {
                if (user.matkhau == password)
                {
                    return 1;
                }
                else { return -1; }
            }
        }
    }
}