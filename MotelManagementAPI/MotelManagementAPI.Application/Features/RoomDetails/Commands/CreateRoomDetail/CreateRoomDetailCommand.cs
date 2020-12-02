using AutoMapper;
using MediatR;
using MotelManagementAPI.Application.Interfaces.Repositories;
using MotelManagementAPI.Application.Wrappers;
using MotelManagementAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotelManagementAPI.Application.Features.RoomDetails.Commands.CreateRoomDetail
{
    public class CreateRoomDetailCommand : IRequest<Response<int>>
    {
        public string RoomNo { get; set; }
        public int? NoOfBed { get; set; }
        public bool? AcnonAc { get; set; }
        public bool IsOccupied { get; set; }
    }
    public class CreateRoomDetailCommandHandler : IRequestHandler<CreateRoomDetailCommand, Response<int>>
    {
        private readonly IRoomDetailsRepositoryAsync _productRepository;
        private readonly IMapper _mapper;
        public CreateRoomDetailCommandHandler(IRoomDetailsRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRoomDetailCommand request, CancellationToken cancellationToken)
        {
            var roomDetail = _mapper.Map<RoomDetail>(request);
            await _productRepository.AddAsync(roomDetail);
            return new Response<int>(roomDetail.Id);
        }
    }
}
