//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopHoaTuoi.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            this.HOADONs = new HashSet<HOADON>();
        }
    
        public int manv { get; set; }
        public string tennv { get; set; }
        public string chucvu { get; set; }
        public string diachi { get; set; }
        public string sdt { get; set; }
        public Nullable<System.DateTime> ngaysinh { get; set; }
        public string email { get; set; }
        public Nullable<decimal> luong { get; set; }
        public string tendangnhap { get; set; }
        public string matkhau { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}