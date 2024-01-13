namespace Finsmart_v19.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public string Others { get; set; } = null!;

        public double Balance { get; set; }

    }
}

