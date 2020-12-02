using MotelManagementAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MotelManagementAPI.Domain.Entities
{
    public class CustomerInfo : AuditableBaseEntity
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public int DocumentId { get; set; }

        public string DocumentNo { get; set; }

        public string PhoneNo { get; set; }

        public virtual Document Document { get; set; }

        public virtual ICollection<CustomerInfo> customerInfos { get; set; }
    }
}
