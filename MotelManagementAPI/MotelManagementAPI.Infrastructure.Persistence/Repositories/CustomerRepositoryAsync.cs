using Microsoft.EntityFrameworkCore;
using MotelManagementAPI.Application.Interfaces.Repositories;
using MotelManagementAPI.Domain.Entities;
using MotelManagementAPI.Infrastructure.Persistence.Contexts;
using MotelManagementAPI.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotelManagementAPI.Infrastructure.Persistence.Repositories
{
    public class CustomerRepositoryAsync : GenericRepositoryAsync<CustomerInfo>, ICustomerRepositoryAsync
    {
        private readonly DbSet<CustomerInfo> _customerInfo;

        public CustomerRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _customerInfo = dbContext.Set<CustomerInfo>();
        }

        public Task<bool> IsDocumentNoUniqueAsync(string documentNo)
        {
            return _customerInfo
                .AllAsync(p => p.DocumentNo != documentNo);
        }
    }
}
