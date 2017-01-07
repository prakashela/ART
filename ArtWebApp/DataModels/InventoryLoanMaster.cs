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
    
    public partial class InventoryLoanMaster
    {
        public decimal Loan_PK { get; set; }
        public string LoanNum { get; set; }
        public Nullable<decimal> FromSkudet_PK { get; set; }
        public Nullable<decimal> FromIIT_Pk { get; set; }
        public Nullable<decimal> ToSkuDet_PK { get; set; }
        public Nullable<decimal> LoanQty { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> PaidBackQty { get; set; }
        public string AddedBY { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<decimal> Location_PK { get; set; }
        public string IsApproved { get; set; }
        public string IsDeleted { get; set; }
        public string ApprovedBy { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public string LoanType { get; set; }
    
        public virtual InventoryLoanMaster InventoryLoanMaster1 { get; set; }
        public virtual InventoryLoanMaster InventoryLoanMaster2 { get; set; }
        public virtual LocationMaster LocationMaster { get; set; }
    }
}
