using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MotelManagementAPI.WebApi.Models
{
    public class OccupiedRoomDetails
    {
        [Key]
        public int Id { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }

        public virtual RoomDetails RoomTest { get; set; }
        public virtual CustomerInfo CustomerTest { get; set; }

    }
}
