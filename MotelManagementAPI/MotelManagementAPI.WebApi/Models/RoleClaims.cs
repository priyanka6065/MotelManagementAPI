using System;
using System.Collections.Generic;

namespace MotelManagementAPI.WebApi.Models
{
    public partial class RoleClaims
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual Role Role { get; set; }
    }
}
