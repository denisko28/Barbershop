using Barbershop.DAL.Interfaces;

namespace Barbershop.DAL.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
