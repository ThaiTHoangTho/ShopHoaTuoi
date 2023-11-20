namespace ShopHoaTuoi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUNHAPHOA")]
    public partial class PHIEUNHAPHOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUNHAPHOA()
        {
            CT_PHIEUNHAPHOA = new HashSet<CT_PHIEUNHAPHOA>();
        }

        [Key]
        public int mapnh { get; set; }

        public int? mancc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaylap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUNHAPHOA> CT_PHIEUNHAPHOA { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}
