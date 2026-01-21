using MyApp.Application.Interface.Repository;
using MyApp.Application.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.UseCases
{
    public class LoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthServices _authServices;
        private readonly IPasswordHasher _passwordHasher;

        public LoginUseCase(IUserRepository userRepository, IAuthServices authServices, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _authServices = authServices;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> ExecuteAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null)
            {
                throw new Exception("Invalid Credentials");
            }

            if(!_passwordHasher.Verify(password, user.Password))
            {
                throw new Exception("Invalid Credentials");
            }

            return await _authServices.GenerateTokenAsync(user);
        }
    }
}
