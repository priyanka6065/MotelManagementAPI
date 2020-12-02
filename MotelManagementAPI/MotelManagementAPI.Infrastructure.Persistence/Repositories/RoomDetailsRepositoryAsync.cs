using Microsoft.EntityFrameworkCore;
using MotelManagementAPI.Application.Interfaces.Repositories;
using MotelManagementAPI.Domain.Entities;
using MotelManagementAPI.Infrastructure.Persistence.Contexts;
using MotelManagementAPI.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotelManagementAPI.Infrastructure.Persistence.Repositories
{
    public class RoomDetailsRepositoryAsync : GenericRepositoryAsync<RoomDetail>, IRoomDetailsRepositoryAsync
    {
        private readonly DbSet<RoomDetail> _roomDetails;

        public RoomDetailsRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _roomDetails = dbContext.Set<RoomDetail>();
        }

        public Task<bool> IsRoomNoUniqueAsync(string roomNo)
        {
            return _roomDetails
                .AllAsync(p => p.RoomNo != roomNo);
        }
    }
}
