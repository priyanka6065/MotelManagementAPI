using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MotelManagementAPI.WebApi.Models
{
     public class Document
    {
        [Key]
        public int DocumentId { get; set; }

        public string DocumentName { get; set; }

        public virtual ICollection<CustomerInfo> CustomerInfos { get; set; }
    }
}
