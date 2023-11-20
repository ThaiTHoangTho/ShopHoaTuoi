namespace ShopHoaTuoi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PHIEUNHAPHOA
    {
        public int id { get; set; }

        public int? mapnh { get; set; }

        public int? mahoa { get; set; }

        [Column(TypeName = "money")]
        public decimal? gianhap { get; set; }

        public int? soluong { get; set; }

        [Column(TypeName = "money")]
        public decimal? tongtien { get; set; }

        public virtual HOA HOA { get; set; }

        public virtual PHIEUNHAPHOA PHIEUNHAPHOA { get; set; }
    }
}
