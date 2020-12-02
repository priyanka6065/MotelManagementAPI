using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MotelManagementAPI.Domain.Entities;

namespace MotelManagementAPI.Application.Interfaces.Repositories
{
    public interface IRoomDetailsRepositoryAsync : IGenericRepositoryAsync<RoomDetail>
    {
        Task<bool> IsRoomNoUniqueAsync(string barcode);
    }
}
