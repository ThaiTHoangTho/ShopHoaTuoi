namespace ShopHoaTuoi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHD")]
    public partial class CTHD
    {
        public int id { get; set; }

        public int? mahd { get; set; }

        public int? mahoa { get; set; }

        public int? soluong { get; set; }

        [Column(TypeName = "money")]
        public decimal? tongtien { get; set; }

        public virtual HOA HOA { get; set; }

        public virtual HOADON HOADON { get; set; }
    }
}
