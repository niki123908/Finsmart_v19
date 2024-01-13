using System.ComponentModel.DataAnnotations;

namespace Finsmart_v19.Dtos
{
    public class LoginDto
    {
        [Display(Name ="Tên Đăng Nhập")]
        [EmailAddress]
        [Required(ErrorMessage="*")]
        public string Email { get; set; } = null!;
        [Display(Name ="Mật Khẩu")]
        [Required(ErrorMessage ="*")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
