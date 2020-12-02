using MotelManagementAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MotelManagementAPI.Domain.Entities
{
    public class Document : AuditableBaseEntity
    {
        public string DocumentName { get; set; }

        public virtual ICollection<CustomerInfo> CustomerInfos { get; set; }
    }
}
