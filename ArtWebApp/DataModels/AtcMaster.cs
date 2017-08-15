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
    
    public partial class AtcMaster
    {
        public AtcMaster()
        {
            this.AtcRawMaterialMasters = new HashSet<AtcRawMaterialMaster>();
            this.DeliveryOrderMasters = new HashSet<DeliveryOrderMaster>();
            this.JobContractOptionalMasters = new HashSet<JobContractOptionalMaster>();
            this.PackingListMasters = new HashSet<PackingListMaster>();
            this.PoPackMasters = new HashSet<PoPackMaster>();
            this.RequestOrderMasters = new HashSet<RequestOrderMaster>();
            this.RequestOrderStockMasters = new HashSet<RequestOrderStockMaster>();
            this.SkuRawMaterialMasters = new HashSet<SkuRawMaterialMaster>();
            this.JobContractMasters = new HashSet<JobContractMaster>();
            this.CutOrderMasters = new HashSet<CutOrderMaster>();
        }
    
        public decimal AtcId { get; set; }
        public string AtcNum { get; set; }
        public decimal Buyer_ID { get; set; }
        public Nullable<decimal> Country_ID { get; set; }
        public string MerchandiserName { get; set; }
        public Nullable<decimal> NoofStyles { get; set; }
        public Nullable<System.DateTime> HouseDate { get; set; }
        public Nullable<System.DateTime> ShipDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public string IsCompleted { get; set; }
        public string IsClosed { get; set; }
        public string SeasonName { get; set; }
        public Nullable<decimal> ProjectionQty { get; set; }
        public string IsProjectionApproved { get; set; }
        public Nullable<decimal> ProductionCountryID { get; set; }
    
        public virtual CountryMaster CountryMaster { get; set; }
        public virtual ICollection<AtcRawMaterialMaster> AtcRawMaterialMasters { get; set; }
        public virtual ICollection<DeliveryOrderMaster> DeliveryOrderMasters { get; set; }
        public virtual ICollection<JobContractOptionalMaster> JobContractOptionalMasters { get; set; }
        public virtual ICollection<PackingListMaster> PackingListMasters { get; set; }
        public virtual ICollection<PoPackMaster> PoPackMasters { get; set; }
        public virtual ICollection<RequestOrderMaster> RequestOrderMasters { get; set; }
        public virtual ICollection<RequestOrderStockMaster> RequestOrderStockMasters { get; set; }
        public virtual ICollection<SkuRawMaterialMaster> SkuRawMaterialMasters { get; set; }
        public virtual ICollection<JobContractMaster> JobContractMasters { get; set; }
        public virtual BuyerMaster BuyerMaster { get; set; }
        public virtual ICollection<CutOrderMaster> CutOrderMasters { get; set; }
    }
}
