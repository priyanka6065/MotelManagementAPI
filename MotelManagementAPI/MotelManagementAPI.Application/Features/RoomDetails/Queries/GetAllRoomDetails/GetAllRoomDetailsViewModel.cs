using System;
using System.Collections.Generic;
using System.Text;

namespace MotelManagementAPI.Application.Features.RoomDetails.Queries.GetAllRoomDetails
{
    public class GetAllRoomDetailsViewModel
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public int? NoOfBed { get; set; }
        public bool? AcnonAc { get; set; }
    }
}
