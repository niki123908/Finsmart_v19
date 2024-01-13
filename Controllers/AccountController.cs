using Finsmart_v19.Dtos;
using Finsmart_v19.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finsmart_v19.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepo;

        public AccountController(IAccountRepository repo) 
        {
            accountRepo = repo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await accountRepo.RegisterAsync(dto);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return StatusCode(500);
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn(LoginDto dto)
        {
            var result = await accountRepo.LoginAsync(dto);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
