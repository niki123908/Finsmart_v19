using AutoMapper;
using Finsmart_v19.Data;
using Finsmart_v19.Dtos;
using Finsmart_v19.Helper;
using Finsmart_v19.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finsmart_v19.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext db;
        private readonly IMapper _mapper;
        public AccountController(DataContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        

        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangKy(RegisterDto model)
        { if (ModelState.IsValid) 
            {
                var User = _mapper.Map<AccountController>(model);
 
            } 
        return View();
        }

     
    }
}
