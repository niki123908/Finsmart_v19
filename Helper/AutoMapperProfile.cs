using AutoMapper;
using Finsmart_v19.Controllers;
using Finsmart_v19.Dtos;

namespace Finsmart_v19.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterDto, AccountController>();
        }
    }
}
