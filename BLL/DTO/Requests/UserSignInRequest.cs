namespace Barbershop.BLL.DTO.Requests
{
    public class UserSignInRequest
    {
        public int Id { get; set; }

        public string? Password { get; set; }

        public string? UserRole { get; set; }
    }
}
