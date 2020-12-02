using System;
using System.Collections.Generic;
using System.Text;

namespace MotelManagementAPI.Application.Features.Customers.Queries.GetAllCustomer
{
    public class GetAllCustomersViewModel
    {
        public int Id { get; set; }
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
    }
}
