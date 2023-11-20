namespace ShopHoaTuoi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHO")]
    public partial class KHO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHO()
        {
            CT_KHO = new HashSet<CT_KHO>();
        }

        [Key]
        public int makho { get; set; }

        [StringLength(100)]
        public string tenkho { get; set; }

        [StringLength(150)]
        public string vitri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_KHO> CT_KHO { get; set; }
    }
}
