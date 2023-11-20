using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShopHoaTuoi.Models.EF
{
    public partial class ShopHoaTuoiEntities : DbContext
    {
        public ShopHoaTuoiEntities()
            : base("name=ShopHoaTuoiDbContext")
        {
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CT_PHIEUNHAPHOA>()
                .Property(e => e.gianhap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CT_PHIEUNHAPHOA>()
                .Property(e => e.tongtien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.tongtien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HOA>()
                .Property(e => e.giaban)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.luong)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PHIEUGIAOHOA>()
                .Property(e => e.phigiaohoa)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PHIEUGIAOHOA>()
                .Property(e => e.tongtien)
                .HasPrecision(19, 4);
        }
    }
}
