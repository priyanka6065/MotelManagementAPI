using MotelManagementAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MotelManagementAPI.Domain.Entities
{
    public class OccupiedRoomDetails : AuditableBaseEntity
    {
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }

        public virtual RoomDetail RoomTest { get; set; }
        public virtual CustomerInfo CustomerTest { get; set; }

    }
}
