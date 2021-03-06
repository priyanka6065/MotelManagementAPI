﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MotelManagementAPI.WebApi.Models
{
    public class CustomerInfo
    {
        [Key]
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

        public virtual Document Document { get; set; }

        public virtual ICollection<OccupiedRoomDetails> OccupiedRoomDetails { get; set; }
    }
}
