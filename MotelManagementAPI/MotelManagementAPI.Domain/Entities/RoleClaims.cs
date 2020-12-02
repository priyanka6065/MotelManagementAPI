using MotelManagementAPI.Domain.Common;
using System;
using System.Collections.Generic;

namespace MotelManagementAPI.Domain.Entities
{
    public partial class RoleClaims : AuditableBaseEntity
    {
        public string RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public virtual Role Role { get; set; }
    }
}
