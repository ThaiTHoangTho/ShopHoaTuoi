﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopHoaTuoi.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShopHoaTuoiEntities : DbContext
    {
        public ShopHoaTuoiEntities()
            : base("name=ShopHoaTuoiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CT_KHO> CT_KHO { get; set; }
        public virtual DbSet<CT_PHIEUNHAPHOA> CT_PHIEUNHAPHOA { get; set; }
        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<HOA> HOAs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<KHO> KHOes { get; set; }
        public virtual DbSet<LOAIHOA> LOAIHOAs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHIEUGIAOHOA> PHIEUGIAOHOAs { get; set; }
        public virtual DbSet<PHIEUNHAPHOA> PHIEUNHAPHOAs { get; set; }
    }
}