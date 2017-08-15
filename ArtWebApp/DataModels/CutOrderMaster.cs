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
    
    public partial class CutOrderMaster
    {
        public CutOrderMaster()
        {
            this.CutOrderDetails = new HashSet<CutOrderDetail>();
            this.CutOrderDOes = new HashSet<CutOrderDO>();
            this.DORollDetails = new HashSet<DORollDetail>();
            this.LaySheetRollDetails = new HashSet<LaySheetRollDetail>();
        }
    
        public decimal CutID { get; set; }
        public string Cut_NO { get; set; }
        public Nullable<decimal> AtcID { get; set; }
        public Nullable<decimal> OurStyleID { get; set; }
        public string Color { get; set; }
        public Nullable<decimal> CutPlan_Pk { get; set; }
        public Nullable<decimal> CutQty { get; set; }
        public string CutWidth { get; set; }
        public string Shrinkage { get; set; }
        public Nullable<decimal> FabQty { get; set; }
        public string CutOrderQty { get; set; }
        public Nullable<decimal> ConsumptionQty { get; set; }
        public string IsCompleted { get; set; }
        public Nullable<decimal> BalanceQty { get; set; }
        public string FabNO { get; set; }
        public Nullable<decimal> DelivedQty { get; set; }
        public Nullable<decimal> FromLoc { get; set; }
        public Nullable<decimal> ToLoc { get; set; }
        public Nullable<System.DateTime> CutOrderDate { get; set; }
        public string AddedBy { get; set; }
        public string CutOrderType { get; set; }
        public Nullable<decimal> SkuDet_pk { get; set; }
        public Nullable<decimal> ExtraReason_Pk { get; set; }
        public string PaternName { get; set; }
        public string MarkerType { get; set; }
        public string CutPlan { get; set; }
        public string IsDeleted { get; set; }
    
        public virtual AtcDetail AtcDetail { get; set; }
        public virtual AtcMaster AtcMaster { get; set; }
        public virtual ICollection<CutOrderDetail> CutOrderDetails { get; set; }
        public virtual ICollection<CutOrderDO> CutOrderDOes { get; set; }
        public virtual ExtraRequestReasonMaster ExtraRequestReasonMaster { get; set; }
        public virtual LocationMaster LocationMaster { get; set; }
        public virtual SkuRawmaterialDetail SkuRawmaterialDetail { get; set; }
        public virtual ICollection<DORollDetail> DORollDetails { get; set; }
        public virtual ICollection<LaySheetRollDetail> LaySheetRollDetails { get; set; }
    }
}
