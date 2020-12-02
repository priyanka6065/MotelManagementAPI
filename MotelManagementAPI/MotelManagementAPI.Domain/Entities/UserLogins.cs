using System;
using System.Collections.Generic;

namespace MotelManagementAPI.Domain.Entities
{
    public partial class UserLogins
    {
        public int Id { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
