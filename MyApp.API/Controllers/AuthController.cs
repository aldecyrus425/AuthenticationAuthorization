using Microsoft.AspNetCore.Mvc;
using MyApp.Application.UseCases;
using MyApp.Domain.DTOs;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {

        private readonly LoginUseCase _loginUseCase;

        public AuthController(LoginUseCase loginUseCase)
        {
            _loginUseCase = loginUseCase;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var token = await _loginUseCase.ExecuteAsync(dto.Email, dto.Password);

            return Ok(new { token });
        }
    }
}
