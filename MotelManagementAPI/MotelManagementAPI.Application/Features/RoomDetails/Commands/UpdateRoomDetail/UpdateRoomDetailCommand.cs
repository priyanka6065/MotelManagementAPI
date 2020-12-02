using MediatR;
using MotelManagementAPI.Application.Exceptions;
using MotelManagementAPI.Application.Interfaces.Repositories;
using MotelManagementAPI.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotelManagementAPI.Application.Features.RoomDetails.Commands.UpdateRoomDetail
{
    public class UpdateRoomDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public int? NoOfBed { get; set; }
        public bool? AcnonAc { get; set; }
        public bool IsOccupied { get; set; }
        public class UpdateRoomDetailCommandHandler : IRequestHandler<UpdateRoomDetailCommand, Response<int>>
        {
            private readonly IRoomDetailsRepositoryAsync _roomDetailRepository;
            public UpdateRoomDetailCommandHandler(IRoomDetailsRepositoryAsync roomDetailRepository)
            {
                _roomDetailRepository = roomDetailRepository;
            }
            public async Task<Response<int>> Handle(UpdateRoomDetailCommand command, CancellationToken cancellationToken)
            {
                var roomDetail = await _roomDetailRepository.GetByIdAsync(command.Id);

                if (roomDetail == null)
                {
                    throw new ApiException($"Room Detail Not Found.");
                }
                else
                {
                    roomDetail.RoomNo = command.RoomNo;
                    roomDetail.NoOfBed = command.NoOfBed;
                    roomDetail.AcnonAc = command.AcnonAc;
                    await _roomDetailRepository.UpdateAsync(roomDetail);
                    return new Response<int>(roomDetail.Id);
                }
            }
        }
    }
}
