using MediatR;
using MotelManagementAPI.Application.Exceptions;
using MotelManagementAPI.Application.Interfaces.Repositories;
using MotelManagementAPI.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotelManagementAPI.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, Response<int>>
        {
            private readonly ICustomerRepositoryAsync _customerRepository;
            public DeleteCustomerByIdCommandHandler(ICustomerRepositoryAsync customerRepository)
            {
                _customerRepository = customerRepository;
            }
            public async Task<Response<int>> Handle(DeleteCustomerByIdCommand command, CancellationToken cancellationToken)
            {
                var customerInfo = await _customerRepository.GetByIdAsync(command.Id);
                if (customerInfo == null) throw new ApiException($"Customer Detail Not Found.");
                await _customerRepository.DeleteAsync(customerInfo);
                return new Response<int>(customerInfo.Id);
            }
        }
    }
}
