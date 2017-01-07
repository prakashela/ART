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
    
    public partial class MrnDetail
    {
        public MrnDetail()
        {
            this.InventoryMasters = new HashSet<InventoryMaster>();
        }
    
        public decimal MrnDet_PK { get; set; }
        public Nullable<decimal> Mrn_PK { get; set; }
        public Nullable<decimal> PODet_PK { get; set; }
        public Nullable<decimal> SkuDet_PK { get; set; }
        public Nullable<decimal> ReceiptQty { get; set; }
        public Nullable<decimal> ExtraQty { get; set; }
        public string Remark { get; set; }
        public Nullable<decimal> Uom_PK { get; set; }
        public Nullable<decimal> Doc_Pk { get; set; }
    
        public virtual ICollection<InventoryMaster> InventoryMasters { get; set; }
        public virtual MrnMaster MrnMaster { get; set; }
        public virtual ProcurementDetail ProcurementDetail { get; set; }
        public virtual SkuRawmaterialDetail SkuRawmaterialDetail { get; set; }
    }
}
