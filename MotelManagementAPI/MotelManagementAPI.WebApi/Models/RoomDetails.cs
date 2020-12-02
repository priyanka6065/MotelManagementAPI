using System;
using System.Collections.Generic;

namespace MotelManagementAPI.WebApi.Models
{
    public partial class RoomDetails
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public int? NoOfBed { get; set; }
        public bool? AcnonAc { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual ICollection<OccupiedRoomDetails> OccupiedRoomDetails { get; set; }
    }
}
