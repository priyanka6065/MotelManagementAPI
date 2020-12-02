using System;
using System.Collections.Generic;
using System.Text;

namespace MotelManagementAPI.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
    }
}
