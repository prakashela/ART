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
    
    public partial class RoInStockDetail
    {
        public decimal RoInStockDet_PK { get; set; }
        public Nullable<decimal> RoInStock_PK { get; set; }
        public Nullable<decimal> RODet_Pk { get; set; }
        public Nullable<decimal> FromSkuDet_PK { get; set; }
        public Nullable<decimal> ToSkuDet_Pk { get; set; }
        public Nullable<decimal> InventoryItem_PK { get; set; }
        public Nullable<decimal> RoQty { get; set; }
        public Nullable<decimal> CuRate { get; set; }
    
        public virtual RequestOrderStockDetail RequestOrderStockDetail { get; set; }
        public virtual RoInStockMaster RoInStockMaster { get; set; }
    }
}
