using System;

namespace Barbershop.BLL.DTO.Requests
{
    public class BarberRequest
    {
        public int Id { get; set; }

        public string? Surname { get; set; }

        public string? Patronymic { get; set; }

        public string? Phone { get; set; }

        public int AccessStatusId { get; set; }

        public string? Password { get; set; }

        public string? Adress { get; set; }

        public string? PassportSeries { get; set; }

        public string? PassportNumber { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
