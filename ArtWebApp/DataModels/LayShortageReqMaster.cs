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
    
    public partial class LayShortageReqMaster
    {
        public LayShortageReqMaster()
        {
            this.LayShortageDetails = new HashSet<LayShortageDetail>();
            this.LayShortageCutorderAdjustments = new HashSet<LayShortageCutorderAdjustment>();
        }
    
        public decimal LayShortageMasterID { get; set; }
        public Nullable<decimal> AtcID { get; set; }
        public Nullable<decimal> Location_PK { get; set; }
        public string AddedBY { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public string LayShortageReqCode { get; set; }
        public string Type { get; set; }
        public Nullable<bool> IsEndBit { get; set; }
        public Nullable<bool> IsLayShortage { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public Nullable<decimal> SkuDet_PK { get; set; }
    
        public virtual ICollection<LayShortageDetail> LayShortageDetails { get; set; }
        public virtual ICollection<LayShortageCutorderAdjustment> LayShortageCutorderAdjustments { get; set; }
    }
}
