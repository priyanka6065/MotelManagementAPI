using AutoMapper;
using MediatR;
using MotelManagementAPI.Application.Interfaces.Repositories;
using MotelManagementAPI.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotelManagementAPI.Application.Features.Customers.Queries.GetAllCustomer
{
    public class GetAllCustomersQuery : IRequest<PagedResponse<IEnumerable<GetAllCustomersViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PagedResponse<IEnumerable<GetAllCustomersViewModel>>>
    {
        private readonly ICustomerRepositoryAsync _customersRepository;
        private readonly IMapper _mapper;
        public GetAllCustomersQueryHandler(ICustomerRepositoryAsync customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllCustomersViewModel>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllCustomersParameter>(request);
            var customers = await _customersRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var customersViewModel = _mapper.Map<IEnumerable<GetAllCustomersViewModel>>(customers);
            return new PagedResponse<IEnumerable<GetAllCustomersViewModel>>(customersViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
