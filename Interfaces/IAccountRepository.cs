
using Finsmart_v19.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Finsmart_v19.Interfaces
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> RegisterAsync(RegisterDto registerDto);
        public Task<string> LoginAsync(LoginDto loginDto);
    }
}
