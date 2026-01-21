using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interface.Services
{
    public interface IPasswordHasher
    {
        bool Verify(string password, string passwordHash);
    }
}
