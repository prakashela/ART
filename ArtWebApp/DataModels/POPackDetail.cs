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
    
    public partial class POPackDetail
    {
        public POPackDetail()
        {
            this.ASQAllocationMasters = new HashSet<ASQAllocationMaster>();
            this.CutPlanASQDetails = new HashSet<CutPlanASQDetail>();
        }
    
        public decimal PoPack_Detail_PK { get; set; }
        public Nullable<decimal> POPackId { get; set; }
        public Nullable<decimal> OurStyleID { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public string SizeName { get; set; }
        public string SIzeCode { get; set; }
        public Nullable<decimal> PoQty { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public string IsCutable { get; set; }
        public string IsPackable { get; set; }
        public Nullable<decimal> ColorId { get; set; }
        public Nullable<decimal> SizeID { get; set; }
        public string IsShortClosed { get; set; }
        public Nullable<decimal> CutQty { get; set; }
        public string IsHidden { get; set; }
        public string IsDeleted { get; set; }
        public string ShortClosedBy { get; set; }
        public string MarkedCuttableBy { get; set; }
        public Nullable<System.DateTime> ShortClosedDate { get; set; }
        public Nullable<System.DateTime> MarkedCuttabledate { get; set; }
    
        public virtual ICollection<ASQAllocationMaster> ASQAllocationMasters { get; set; }
        public virtual AtcDetail AtcDetail { get; set; }
        public virtual ICollection<CutPlanASQDetail> CutPlanASQDetails { get; set; }
        public virtual PoPackMaster PoPackMaster { get; set; }
    }
}
