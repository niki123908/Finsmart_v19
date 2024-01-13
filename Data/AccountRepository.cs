using Finsmart_final.Entities;
using Finsmart_v19.Dtos;
using Finsmart_v19.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Finsmart_final.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly RoleManager<IdentityRole> _role;
        private readonly UserManager<AppUser> _userManeger;
        private readonly SignInManager<AppUser> _signInManeger;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountRepository> _logger;

        public AccountRepository(UserManager<AppUser> userManeger, SignInManager<AppUser> signInManager, IConfiguration configuration, ILogger<AccountRepository> logger, RoleManager<IdentityRole> role) 
        {
            _role = role;
            _userManeger = userManeger;
            _signInManeger = signInManager;
            _configuration = configuration;
            _logger = logger;
        }
        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManeger.FindByEmailAsync(loginDto.Email);
            var pwCheck = await _userManeger.CheckPasswordAsync(user, loginDto.Password);
            if (user == null || !pwCheck)
            {
                return string.Empty;
            }
            var result = await _signInManeger.PasswordSignInAsync
                (loginDto.Email, loginDto.Password, false, false);

            if (!result.Succeeded) {
                _logger.LogError("Login failed for user: {User}", loginDto.Email);
                return string.Empty;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, loginDto.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var userRoles = await _userManeger.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(
                    new Claim(ClaimTypes.Role, role.ToString())
                    );
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                Others = registerDto.Others,
                Password = registerDto.Password,
            };
            var result = await _userManeger.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                if(!await _role.RoleExistsAsync(AppRole.User))
                {
                    await _role.CreateAsync(new IdentityRole
                        (AppRole.User));
                }

                await _userManeger.AddToRoleAsync(user, AppRole.User);
            }
            return result;
        }
    }
}
