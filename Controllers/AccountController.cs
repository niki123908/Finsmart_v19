using Finsmart_v19.Data;
using Finsmart_v19.Dtos;
using Finsmart_v19.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finsmart_v19.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext db;
        public AccountController(DataContext context)
        {
            db = context;

        }

        public IActionResult DangKy()
        {
            return View();
        }

     
    }
}
