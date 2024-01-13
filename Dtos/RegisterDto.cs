using System.ComponentModel.DataAnnotations;

namespace Finsmart_v19.Dtos
{
    public class RegisterDto
    {
        [Display(Name = "Email")]   
        [EmailAddress(ErrorMessage = "Chưa đúng định dạng email")]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "*")]
        [MinLength(8, ErrorMessage = "Tối thiểu 8 ký tự")]
        public string Password { get; set; }
        [Display(Name = "Confirm password")]
        [Required] public string ConfirmPassword { get; set; }
        [Display(Name = "Tên đăng nhập")]
        [Required] public string Username { get; set; }
        [Required] public string Others { get; set; } = null!;
        public string RandomKey { get; set; }
    }
}
