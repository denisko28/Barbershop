using Barbershop.DAL.Interfaces;

namespace Barbershop.DAL.Entities.Base
{
    public abstract class Person : NamedEntity, IPerson
    {
        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Phone { get; set; }

        public int AccessStatusId { get; set; }

        public AccessStatus AccessStatus { get; set; }

        public string Password { get; set; }
    }
}