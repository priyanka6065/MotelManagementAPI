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

namespace MotelManagementAPI.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Response<int>>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public int DocumentId { get; set; }

        public string DocumentNo { get; set; }

        public string PhoneNo { get; set; }
    }
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<int>>
    {
        private readonly ICustomerRepositoryAsync _customerRepository;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(ICustomerRepositoryAsync customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerInfo = _mapper.Map<CustomerInfo>(request);
            await _customerRepository.AddAsync(customerInfo);
            return new Response<int>(customerInfo.Id);
        }
    }
}
