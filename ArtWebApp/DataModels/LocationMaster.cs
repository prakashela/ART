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
    
    public partial class LocationMaster
    {
        public LocationMaster()
        {
            this.DeliveryOrderMasters = new HashSet<DeliveryOrderMaster>();
            this.DeliveryOrderMasters1 = new HashSet<DeliveryOrderMaster>();
            this.DeliveryOrderStockMasters = new HashSet<DeliveryOrderStockMaster>();
            this.DeliveryOrderStockMasters1 = new HashSet<DeliveryOrderStockMaster>();
            this.DeliveryReceiptMasters = new HashSet<DeliveryReceiptMaster>();
            this.FactWareLinkMasters = new HashSet<FactWareLinkMaster>();
            this.FactWareLinkMasters1 = new HashSet<FactWareLinkMaster>();
            this.InventoryLoanMasters = new HashSet<InventoryLoanMaster>();
            this.InventoryMasters = new HashSet<InventoryMaster>();
            this.InventorySalesMasters = new HashSet<InventorySalesMaster>();
            this.JobContractOptionalMasters = new HashSet<JobContractOptionalMaster>();
            this.MrnMasters = new HashSet<MrnMaster>();
            this.RecieptMasters = new HashSet<RecieptMaster>();
            this.RequestOrderMasters = new HashSet<RequestOrderMaster>();
            this.RequestOrderStockMasters = new HashSet<RequestOrderStockMaster>();
            this.ROINMasters = new HashSet<ROINMaster>();
            this.RoInStockMasters = new HashSet<RoInStockMaster>();
            this.SDocMasters = new HashSet<SDocMaster>();
            this.ShipmentHandOverMasters = new HashSet<ShipmentHandOverMaster>();
            this.StockMrnMasters = new HashSet<StockMrnMaster>();
            this.StockRecieptMasters = new HashSet<StockRecieptMaster>();
            this.StockSDocMasters = new HashSet<StockSDocMaster>();
            this.TransferToGstockMasters = new HashSet<TransferToGstockMaster>();
            this.CutPlanMasters = new HashSet<CutPlanMaster>();
            this.DocMasters = new HashSet<DocMaster>();
            this.JobContractMasters = new HashSet<JobContractMaster>();
            this.SupplierDocumentMasters = new HashSet<SupplierDocumentMaster>();
            this.UserMasters = new HashSet<UserMaster>();
            this.DeviceMasters = new HashSet<DeviceMaster>();
            this.CutOrderMasters = new HashSet<CutOrderMaster>();
            this.RejectionExtraFabbReqs = new HashSet<RejectionExtraFabbReq>();
            this.LocationGroupDetails = new HashSet<LocationGroupDetail>();
            this.LocationGroupMasters = new HashSet<LocationGroupMaster>();
            this.PatternNameBanks = new HashSet<PatternNameBank>();
        }
    
        public decimal Location_PK { get; set; }
        public string LocationName { get; set; }
        public string LocationPrefix { get; set; }
        public string LocationAddress { get; set; }
        public Nullable<decimal> LocationType_PK { get; set; }
        public string LocType { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string ContactPerson { get; set; }
        public Nullable<decimal> CurrencyID { get; set; }
        public Nullable<decimal> CountryID { get; set; }
        public Nullable<decimal> PaymentModeID { get; set; }
        public Nullable<decimal> PaymentTermID { get; set; }
        public string IsActive { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
    
        public virtual ICollection<DeliveryOrderMaster> DeliveryOrderMasters { get; set; }
        public virtual ICollection<DeliveryOrderMaster> DeliveryOrderMasters1 { get; set; }
        public virtual ICollection<DeliveryOrderStockMaster> DeliveryOrderStockMasters { get; set; }
        public virtual ICollection<DeliveryOrderStockMaster> DeliveryOrderStockMasters1 { get; set; }
        public virtual ICollection<DeliveryReceiptMaster> DeliveryReceiptMasters { get; set; }
        public virtual ICollection<FactWareLinkMaster> FactWareLinkMasters { get; set; }
        public virtual ICollection<FactWareLinkMaster> FactWareLinkMasters1 { get; set; }
        public virtual ICollection<InventoryLoanMaster> InventoryLoanMasters { get; set; }
        public virtual ICollection<InventoryMaster> InventoryMasters { get; set; }
        public virtual ICollection<InventorySalesMaster> InventorySalesMasters { get; set; }
        public virtual ICollection<JobContractOptionalMaster> JobContractOptionalMasters { get; set; }
        public virtual ICollection<MrnMaster> MrnMasters { get; set; }
        public virtual ICollection<RecieptMaster> RecieptMasters { get; set; }
        public virtual ICollection<RequestOrderMaster> RequestOrderMasters { get; set; }
        public virtual ICollection<RequestOrderStockMaster> RequestOrderStockMasters { get; set; }
        public virtual ICollection<ROINMaster> ROINMasters { get; set; }
        public virtual ICollection<RoInStockMaster> RoInStockMasters { get; set; }
        public virtual ICollection<SDocMaster> SDocMasters { get; set; }
        public virtual ICollection<ShipmentHandOverMaster> ShipmentHandOverMasters { get; set; }
        public virtual ICollection<StockMrnMaster> StockMrnMasters { get; set; }
        public virtual ICollection<StockRecieptMaster> StockRecieptMasters { get; set; }
        public virtual ICollection<StockSDocMaster> StockSDocMasters { get; set; }
        public virtual ICollection<TransferToGstockMaster> TransferToGstockMasters { get; set; }
        public virtual ICollection<CutPlanMaster> CutPlanMasters { get; set; }
        public virtual ICollection<DocMaster> DocMasters { get; set; }
        public virtual ICollection<JobContractMaster> JobContractMasters { get; set; }
        public virtual ICollection<SupplierDocumentMaster> SupplierDocumentMasters { get; set; }
        public virtual ICollection<UserMaster> UserMasters { get; set; }
        public virtual ICollection<DeviceMaster> DeviceMasters { get; set; }
        public virtual ICollection<CutOrderMaster> CutOrderMasters { get; set; }
        public virtual ICollection<RejectionExtraFabbReq> RejectionExtraFabbReqs { get; set; }
        public virtual ICollection<LocationGroupDetail> LocationGroupDetails { get; set; }
        public virtual ICollection<LocationGroupMaster> LocationGroupMasters { get; set; }
        public virtual ICollection<PatternNameBank> PatternNameBanks { get; set; }
    }
}
