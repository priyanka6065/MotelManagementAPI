using MotelManagementAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotelManagementAPI.Application.Interfaces.Repositories
{
    public interface ICustomerRepositoryAsync : IGenericRepositoryAsync<CustomerInfo>
    {
        Task<bool> IsDocumentNoUniqueAsync(string barcode);
    }
}
