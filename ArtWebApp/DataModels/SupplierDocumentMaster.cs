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
    
    public partial class SupplierDocumentMaster
    {
        public decimal SupplierDoc_pk { get; set; }
        public Nullable<decimal> Supplier_pk { get; set; }
        public string SupplierDocnum { get; set; }
        public Nullable<System.DateTime> SupplierETA { get; set; }
        public string Containernum { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string AtracotrackingNum { get; set; }
    }
}
