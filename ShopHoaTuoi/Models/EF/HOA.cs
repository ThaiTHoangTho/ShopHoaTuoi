namespace ShopHoaTuoi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOA")]
    public partial class HOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOA()
        {
            CT_KHO = new HashSet<CT_KHO>();
            CT_PHIEUNHAPHOA = new HashSet<CT_PHIEUNHAPHOA>();
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        public int mahoa { get; set; }

        public int? maloai { get; set; }

        [StringLength(100)]
        public string tenhoa { get; set; }

        [StringLength(200)]
        public string anh { get; set; }

        [Column(TypeName = "money")]
        public decimal? giaban { get; set; }

        [StringLength(500)]
        public string mota { get; set; }

        public bool banchay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_KHO> CT_KHO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUNHAPHOA> CT_PHIEUNHAPHOA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual LOAIHOA LOAIHOA { get; set; }
    }
}
