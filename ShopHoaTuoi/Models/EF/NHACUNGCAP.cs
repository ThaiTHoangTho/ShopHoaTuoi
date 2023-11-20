namespace ShopHoaTuoi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHACUNGCAP")]
    public partial class NHACUNGCAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHACUNGCAP()
        {
            PHIEUNHAPHOAs = new HashSet<PHIEUNHAPHOA>();
        }

        [Key]
        public int mancc { get; set; }

        [StringLength(100)]
        public string tenncc { get; set; }

        [StringLength(150)]
        public string diachi { get; set; }

        [StringLength(11)]
        public string sdt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAPHOA> PHIEUNHAPHOAs { get; set; }
    }
}
