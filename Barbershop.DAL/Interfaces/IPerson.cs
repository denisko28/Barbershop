using Barbershop.DAL.Entities;

namespace Barbershop.DAL.Interfaces
{
    public interface IPerson : IEntity
    {
        string Surname { get; set; }

        string Patronymic { get; set; }

        string Phone { get; set; }

        int AccessStatusId { get; set; }

        AccessStatus AccessStatus { get; set; }

        string Password { get; set; }
    }
}
