using Finsmart_final.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Finsmart_v19.Controllers
{
    public class BalanceController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public BalanceController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            return View(user.Balance);
        }
    }
}
