namespace ShopHoaTuoi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUGIAOHOA")]
    public partial class PHIEUGIAOHOA
    {
        [Key]
        public int mapgh { get; set; }

        [Column(TypeName = "money")]
        public decimal? phigiaohoa { get; set; }

        [Column(TypeName = "money")]
        public decimal? tongtien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaygiao { get; set; }
    }
}
