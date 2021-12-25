using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Exceptions;
using Barbershop.DAL.Interfaces.Repositories;
using Barbershop.DAL.Parameters;
using Barbershop.DAL.Context;
using System;


namespace Barbershop.DAL.Data.Repositories
{
    public class AccessStatusRepository : GenericRepository<AccessStatus>, IAccessStatusRepository
    {
        public override async Task<AccessStatus> GetCompleteEntityAsync(int id)
        {
            var accessStatus = await table.Include(appointment => appointment.Customers)
                                     .Include(appointment => appointment.Barbers)
                                     .FirstAsync(appointment => appointment.Id == id);

            return accessStatus ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        public AccessStatusRepository(BarbershopDB databaseContext)
            : base(databaseContext)
        {
        }
    }
}
