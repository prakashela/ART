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
    
    public partial class SupplierInvoiceDetail
    {
        public decimal SupplierInvoiceDet_PK { get; set; }
        public Nullable<decimal> SupplierInvoice_PK { get; set; }
        public Nullable<decimal> PODet_PK { get; set; }
        public Nullable<decimal> InvoiceQty { get; set; }
        public Nullable<decimal> Unitrate { get; set; }
        public string InvCurrency { get; set; }
    
        public virtual ProcurementDetail ProcurementDetail { get; set; }
        public virtual SupplierInvoiceMaster SupplierInvoiceMaster { get; set; }
    }
}
