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
    
    public partial class CutPlanMaster
    {
        public CutPlanMaster()
        {
            this.CutPlanASQDetails = new HashSet<CutPlanASQDetail>();
            this.CutPlanMarkerTypes = new HashSet<CutPlanMarkerType>();
        }
    
        public decimal CutPlan_PK { get; set; }
        public Nullable<decimal> OurStyleID { get; set; }
        public Nullable<decimal> SkuDet_PK { get; set; }
        public Nullable<decimal> Location_PK { get; set; }
        public string CutPlanNUM { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public string ShrinkageGroup { get; set; }
        public string WidthGroup { get; set; }
        public string FabDescription { get; set; }
        public string MarkerType { get; set; }
        public Nullable<decimal> BOMConsumption { get; set; }
        public string Maxmarkerlength { get; set; }
        public string MarkerMade { get; set; }
        public string Fabrication { get; set; }
        public string RefPattern { get; set; }
        public Nullable<decimal> CutPlanFabReq { get; set; }
        public Nullable<decimal> CutplanEfficency { get; set; }
        public Nullable<decimal> CutplanConsumption { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public string IsRatioAdded { get; set; }
        public string RatioAddedBy { get; set; }
        public Nullable<System.DateTime> RatioAddedDate { get; set; }
        public string IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public string IsPatternAdded { get; set; }
        public string PatternAddedBy { get; set; }
        public string IsCutorderGiven { get; set; }
        public string IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string NewPatternName { get; set; }
    
        public virtual AtcDetail AtcDetail { get; set; }
        public virtual ICollection<CutPlanASQDetail> CutPlanASQDetails { get; set; }
        public virtual ICollection<CutPlanMarkerType> CutPlanMarkerTypes { get; set; }
        public virtual LocationMaster LocationMaster { get; set; }
        public virtual SkuRawmaterialDetail SkuRawmaterialDetail { get; set; }
    }
}
