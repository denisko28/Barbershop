namespace Barbershop.BLL.DTO.Requests
{
    public class CustomerRequest
    {
        public int Id { get; set; }

        public string? Surname { get; set; }

        public string? Patronymic { get; set; }

        public string? Phone { get; set; }

        public int AccessStatusId { get; set; }

        public string? Password { get; set; }
    }
}
