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
    
    public partial class DeliveryReceiptMaster
    {
        public decimal DOR_PK { get; set; }
        public string DORNum { get; set; }
        public Nullable<decimal> Location_PK { get; set; }
        public Nullable<decimal> DO_PK { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public string DOReceiptType { get; set; }
    
        public virtual DeliveryOrderMaster DeliveryOrderMaster { get; set; }
        public virtual LocationMaster LocationMaster { get; set; }
    }
}
