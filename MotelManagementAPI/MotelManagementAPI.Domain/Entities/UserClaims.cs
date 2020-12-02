using MotelManagementAPI.Domain.Common;
using System;
using System.Collections.Generic;

namespace MotelManagementAPI.Domain.Entities
{
    public partial class UserClaims : AuditableBaseEntity
    {
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual User User { get; set; }
    }
}
