//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArtWebApp.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeviceType
    {
        public DeviceType()
        {
            this.DeviceMasters = new HashSet<DeviceMaster>();
        }
    
        public decimal DeviceTypeID { get; set; }
        public string DeviceTypeName { get; set; }
        public bool IsActive { get; set; }
    
        public virtual ICollection<DeviceMaster> DeviceMasters { get; set; }
    }
}
