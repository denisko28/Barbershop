namespace Barbershop.BLL.DTO.Requests
{
    public class CustomerSignUpRequest
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Patronymic { get; set; }

        public string? Phone { get; set; }

        public string? Password { get; set; }
    }
}
