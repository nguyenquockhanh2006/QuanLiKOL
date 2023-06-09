//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MXHvaQLKOL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccCustomer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccCustomer()
        {
            this.AnhKhaches = new HashSet<AnhKhach>();
            this.BaiDangCus = new HashSet<BaiDangCu>();
            this.Follows = new HashSet<Follow>();
            this.HopDongs = new HashSet<HopDong>();
            this.LuotThichBvKOLs = new HashSet<LuotThichBvKOL>();
            this.LVKHs = new HashSet<LVKH>();
            this.reports = new HashSet<report>();
        }
    
        public string AccName { get; set; }
        public string UseName { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> BirthDay { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] Avatar { get; set; }
        public byte[] CCCD { get; set; }
        public byte[] CCCDback { get; set; }
        public string Gmail { get; set; }
        public string SoCM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnhKhach> AnhKhaches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiDangCu> BaiDangCus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Follow> Follows { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDong> HopDongs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuotThichBvKOL> LuotThichBvKOLs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LVKH> LVKHs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<report> reports { get; set; }
    }
}
