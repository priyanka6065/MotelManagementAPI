using MotelManagementAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotelManagementAPI.Domain.Entities
{
    public class RoomDetail : AuditableBaseEntity
    {
        public string RoomNo { get; set; }
        public int? NoOfBed { get; set; }
        public bool? AcnonAc { get; set; }
        public bool IsOccupied { get; set; }
        public virtual ICollection<OccupiedRoomDetails> OccupiedRoomDetails { get; set; }
    }
}
