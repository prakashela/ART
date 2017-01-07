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
    
    public partial class MrnMaster
    {
        public MrnMaster()
        {
            this.MrnDetails = new HashSet<MrnDetail>();
        }
    
        public decimal Mrn_PK { get; set; }
        public string MrnNum { get; set; }
        public Nullable<decimal> Po_PK { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string Remark { get; set; }
        public string AddedBY { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public string DoNumber { get; set; }
        public Nullable<decimal> Location_Pk { get; set; }
        public Nullable<decimal> Reciept_Pk { get; set; }
    
        public virtual LocationMaster LocationMaster { get; set; }
        public virtual ICollection<MrnDetail> MrnDetails { get; set; }
        public virtual MrnMaster MrnMaster1 { get; set; }
        public virtual MrnMaster MrnMaster2 { get; set; }
        public virtual RecieptMaster RecieptMaster { get; set; }
    }
}
