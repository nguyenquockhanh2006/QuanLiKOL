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
    
    public partial class AccAdmin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccAdmin()
        {
            this.BaiDangAdmins = new HashSet<BaiDangAdmin>();
            this.HoiDaps = new HashSet<HoiDap>();
            this.HopDongs = new HashSet<HopDong>();
        }
    
        public string AccName { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> BirthDay { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] Avatar { get; set; }
        public byte[] CCCD { get; set; }
        public byte[] CCCDback { get; set; }
        public string SoCM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiDangAdmin> BaiDangAdmins { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoiDap> HoiDaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDong> HopDongs { get; set; }
    }
}
