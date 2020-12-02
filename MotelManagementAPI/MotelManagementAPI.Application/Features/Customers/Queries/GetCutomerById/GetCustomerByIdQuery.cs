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

namespace MotelManagementAPI.Application.Features.Customers.Queries.GetCutomerById
{
    public class GetCustomerByIdQuery : IRequest<Response<CustomerInfo>>
    {
        public int Id { get; set; }
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<CustomerInfo>>
        {
            private readonly ICustomerRepositoryAsync _customerRepository;
            public GetCustomerByIdQueryHandler(ICustomerRepositoryAsync customerRepository)
            {
                _customerRepository = customerRepository;
            }
            public async Task<Response<CustomerInfo>> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
            {
                var customerInfo = await _customerRepository.GetByIdAsync(query.Id);
                if (customerInfo == null) throw new ApiException($"Customer Detail Not Found.");
                return new Response<CustomerInfo>(customerInfo);
            }
        }
    }
}
