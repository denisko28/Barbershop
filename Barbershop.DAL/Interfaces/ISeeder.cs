using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Barbershop.DAL.Interfaces
{
    public interface ISeeder<T> where T : class
    {
        void Seed(EntityTypeBuilder<T> builder);
    }
}
