using System.ComponentModel.DataAnnotations.Schema;

namespace Barbershop.DAL.Entities.Base
{
    public abstract class NamedEntity : Entity
    {
        public string Name { get; set; }
    }
}