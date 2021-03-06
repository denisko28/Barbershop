using System;
using System.Collections.Generic;
using System.Text;

namespace Barbershop.BLL.DTO.Responses
{
    public class ServiceResponse
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public int Discount { get; set; }

        public int Duration { get; set; }

        public bool Enabled { get; set; }
    }
}
