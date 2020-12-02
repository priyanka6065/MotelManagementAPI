using MediatR;
using MotelManagementAPI.Application.Exceptions;
using MotelManagementAPI.Application.Interfaces.Repositories;
using MotelManagementAPI.Application.Wrappers;
using MotelManagementAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotelManagementAPI.Application.Features.RoomDetails.Queries.GetRoomDetailById
{
    public class GetRoomDetailByIdQuery : IRequest<Response<RoomDetail>>
    {
        public int Id { get; set; }
        public class GetRoomDetailByIdQueryHandler : IRequestHandler<GetRoomDetailByIdQuery, Response<RoomDetail>>
        {
            private readonly IRoomDetailsRepositoryAsync _roomDetailRepository;
            public GetRoomDetailByIdQueryHandler(IRoomDetailsRepositoryAsync roomDetailRepository)
            {
                _roomDetailRepository = roomDetailRepository;
            }
            public async Task<Response<RoomDetail>> Handle(GetRoomDetailByIdQuery query, CancellationToken cancellationToken)
            {
                var roomDetail = await _roomDetailRepository.GetByIdAsync(query.Id);
                if (roomDetail == null) throw new ApiException($"Room Detail Not Found.");
                return new Response<RoomDetail>(roomDetail);
            }
        }
    }
}
