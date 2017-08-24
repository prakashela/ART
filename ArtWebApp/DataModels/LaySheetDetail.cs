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
    
    public partial class LaySheetDetail
    {
        public LaySheetDetail()
        {
            this.LayShortageDetails = new HashSet<LayShortageDetail>();
        }
    
        public decimal LaySheetDet_PK { get; set; }
        public Nullable<decimal> LaySheet_PK { get; set; }
        public Nullable<decimal> Roll_PK { get; set; }
        public Nullable<decimal> NoOfPlies { get; set; }
        public Nullable<decimal> FabUtilized { get; set; }
        public Nullable<decimal> EndBit { get; set; }
        public Nullable<decimal> BalToCut { get; set; }
        public Nullable<decimal> ExcessOrShort { get; set; }
        public string IsRecuttable { get; set; }
        public Nullable<decimal> LaySheetRoll_Pk { get; set; }
    
        public virtual LaySheetMaster LaySheetMaster { get; set; }
        public virtual FabricRollmaster FabricRollmaster { get; set; }
        public virtual ICollection<LayShortageDetail> LayShortageDetails { get; set; }
        public virtual LaySheetRollDetail LaySheetRollDetail { get; set; }
    }
}
