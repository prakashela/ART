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
    
    public partial class DepartmentMaster
    {
        public DepartmentMaster()
        {
            this.UserMasters = new HashSet<UserMaster>();
        }
    
        public decimal Deapartment_PK { get; set; }
        public string DepartmentName { get; set; }
    
        public virtual ICollection<UserMaster> UserMasters { get; set; }
    }
}
