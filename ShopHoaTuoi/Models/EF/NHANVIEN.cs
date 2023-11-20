namespace ShopHoaTuoi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        public int manv { get; set; }

        [StringLength(100)]
        public string tennv { get; set; }

        [StringLength(50)]
        public string chucvu { get; set; }

        [StringLength(150)]
        public string diachi { get; set; }

        [StringLength(11)]
        public string sdt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysinh { get; set; }

        [StringLength(80)]
        public string email { get; set; }

        [Column(TypeName = "money")]
        public decimal? luong { get; set; }

        [StringLength(50)]
        public string tendangnhap { get; set; }

        [StringLength(10)]
        public string matkhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
