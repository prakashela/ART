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
    
    public partial class DeliveryTermMaster
    {
        public DeliveryTermMaster()
        {
            this.StockPOMasters = new HashSet<StockPOMaster>();
        }
    
        public decimal DeliveryTerms_Pk { get; set; }
        public string DeliveryTerm { get; set; }
    
        public virtual ICollection<StockPOMaster> StockPOMasters { get; set; }
    }
}
