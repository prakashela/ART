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
    
    public partial class UserProfileMaster
    {
        public UserProfileMaster()
        {
            this.UserMasters = new HashSet<UserMaster>();
            this.UserProfileRights = new HashSet<UserProfileRight>();
        }
    
        public decimal UserProfile_Pk { get; set; }
        public string UserProfileName { get; set; }
        public string UserProfileCode { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    
        public virtual ICollection<UserMaster> UserMasters { get; set; }
        public virtual ICollection<UserProfileRight> UserProfileRights { get; set; }
    }
}