using MediatR;
using MotelManagementAPI.Application.Exceptions;
using MotelManagementAPI.Application.Interfaces.Repositories;
using MotelManagementAPI.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotelManagementAPI.Application.Features.RoomDetails.Commands.DeleteRoomDetail
{
    public class DeleteRoomDetailByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteRoomDetailByIdCommandHandler : IRequestHandler<DeleteRoomDetailByIdCommand, Response<int>>
        {
            private readonly IRoomDetailsRepositoryAsync _roomDetailRepository;
            public DeleteRoomDetailByIdCommandHandler(IRoomDetailsRepositoryAsync roomDetailRepository)
            {
                _roomDetailRepository = roomDetailRepository;
            }
            public async Task<Response<int>> Handle(DeleteRoomDetailByIdCommand command, CancellationToken cancellationToken)
            {
                var roomDetail = await _roomDetailRepository.GetByIdAsync(command.Id);
                if (roomDetail == null) throw new ApiException($"Room Detail Not Found.");
                await _roomDetailRepository.DeleteAsync(roomDetail);
                return new Response<int>(roomDetail.Id);
            }
        }
    }
}
