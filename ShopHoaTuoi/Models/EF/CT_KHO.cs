namespace ShopHoaTuoi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_KHO
    {
        public int id { get; set; }

        public int? makho { get; set; }

        public int? mahoa { get; set; }

        public int? soluong { get; set; }

        public virtual HOA HOA { get; set; }

        public virtual KHO KHO { get; set; }
    }
}
