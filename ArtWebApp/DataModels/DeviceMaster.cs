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
    
    public partial class DeviceMaster
    {
        public decimal NodeID { get; set; }
        public string MacID { get; set; }
        public string DeviceName { get; set; }
        public string IPAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Manufacturer { get; set; }
        public Nullable<decimal> DeviceType { get; set; }
        public Nullable<decimal> Location_PK { get; set; }
        public bool IsActive { get; set; }
        public string Remark { get; set; }
        public string SerialNumber { get; set; }
        public string OSRef { get; set; }
    
        public virtual DeviceType DeviceType1 { get; set; }
        public virtual LocationMaster LocationMaster { get; set; }
    }
}