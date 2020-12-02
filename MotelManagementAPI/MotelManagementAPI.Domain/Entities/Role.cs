using MotelManagementAPI.Domain.Common;
using System;
using System.Collections.Generic;

namespace MotelManagementAPI.Domain.Entities
{
    public partial class Role : AuditableBaseEntity
    {
        public Role()
        {
            RoleClaims = new HashSet<RoleClaims>();
            UserRoles = new HashSet<UserRoles>();
        }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual ICollection<RoleClaims> RoleClaims { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
