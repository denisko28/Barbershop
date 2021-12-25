namespace Barbershop.BLL.DTO.Responses
{
    public class CustomerResponse
    {
        public int Id { get; set; }

        public string? Surname { get; set; }

        public string? Patronymic { get; set; }

        public string? Phone { get; set; }

        public int AccessStatusId { get; set; }

        public AccessStatusResponse? AccessStatus { get; set; }

        public string? Password { get; set; }
    }
}
