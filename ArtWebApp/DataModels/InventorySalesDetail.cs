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
    
    public partial class InventorySalesDetail
    {
        public decimal SalesDODet_PK { get; set; }
        public Nullable<decimal> SalesDO_PK { get; set; }
        public Nullable<decimal> SInventoryItem_PK { get; set; }
        public Nullable<decimal> DeliveryQty { get; set; }
        public Nullable<decimal> Unitprice { get; set; }
        public string Remark { get; set; }
        public Nullable<decimal> CuRate { get; set; }
    
        public virtual InventorySalesMaster InventorySalesMaster { get; set; }
    }
}
