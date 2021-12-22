using System;
using System.Collections.Generic;
using System.Text;

namespace Barbershop.DAL.Parameters
{
    public class CustomerParams
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Phone { get; set; }

        public int AccessStatusId { get; set; }
    }
}
