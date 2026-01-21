using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interface.Services
{
    public interface IAuthServices
    {
        Task<string> GenerateTokenAsync(User user);
    }
}
