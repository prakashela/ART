//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArtWebApp.DataModelAtcWorld
{
    using System;
    using System.Collections.Generic;
    
    public partial class ArtLaySheetMasterData
    {
        public decimal LayMasterDataID { get; set; }
        public string CutPlanNUM { get; set; }
        public string ColorCode { get; set; }
        public string LaySheetNum { get; set; }
        public string LayCutNum { get; set; }
        public string LocationName { get; set; }
        public Nullable<decimal> Location_PK { get; set; }
        public Nullable<decimal> CutOrderDet_PK { get; set; }
        public Nullable<decimal> CutID { get; set; }
        public string Cut_NO { get; set; }
        public string Shrinkage { get; set; }
        public string MarkerType { get; set; }
        public string CutWidth { get; set; }
        public Nullable<decimal> AtcID { get; set; }
        public string IsApproved { get; set; }
        public Nullable<decimal> OurStyleID { get; set; }
        public Nullable<decimal> CutPlan_PK { get; set; }
        public Nullable<decimal> LaySheet_PK { get; set; }
    }
}