using AutoMapper;
using MediatR;
using MotelManagementAPI.Application.Interfaces.Repositories;
using MotelManagementAPI.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotelManagementAPI.Application.Features.RoomDetails.Queries.GetAllRoomDetails
{
    public class GetAllRoomDetailsQuery : IRequest<PagedResponse<IEnumerable<GetAllRoomDetailsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllRoomDetailsQueryHandler : IRequestHandler<GetAllRoomDetailsQuery, PagedResponse<IEnumerable<GetAllRoomDetailsViewModel>>>
    {
        private readonly IRoomDetailsRepositoryAsync _roomDetailsRepository;
        private readonly IMapper _mapper;
        public GetAllRoomDetailsQueryHandler(IRoomDetailsRepositoryAsync roomDetailsRepository, IMapper mapper)
        {
            _roomDetailsRepository = roomDetailsRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllRoomDetailsViewModel>>> Handle(GetAllRoomDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllRoomDetailsParameter>(request);
            var roomDetail = await _roomDetailsRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var roomDetailsViewModel = _mapper.Map<IEnumerable<GetAllRoomDetailsViewModel>>(roomDetail);
            return new PagedResponse<IEnumerable<GetAllRoomDetailsViewModel>>(roomDetailsViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }


}
