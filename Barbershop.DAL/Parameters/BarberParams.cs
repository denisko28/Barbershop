using System;
using System.Collections.Generic;
using System.Text;

namespace Barbershop.DAL.Parameters
{
    public class BarberParams
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Phone { get; set; }

        public int AccessStatusId { get; set; }

        public string Adress { get; set; }
    }
}
