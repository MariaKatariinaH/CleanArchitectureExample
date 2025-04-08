using CleanArchitectureExample.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading.Tasks;

namespace CleanArchitectureExample.Application.Interfaces
{
    public interface IUserRegistrationService
    {
        //bool RegisterUser(string name, string email);

        //bool EmailExists(string email);

        
        Task<bool> EmailExistsAsync(string email);
        Task<bool> RegisterUserAsync(string name, string email);
    }
}

