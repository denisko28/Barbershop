using System;
using System.Collections.Generic;
using System.Text;

namespace Barbershop.DAL.Parameters
{
    public class ServiceParams
    {
        public string Name { get; set; }

        public decimal? Price { get; set; }

        public int? Discount { get; set; }

        public int? Duration { get; set; }

        public bool? Enabled { get; set; }
    }
}
