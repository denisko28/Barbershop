namespace Barbershop.BLL.DTO.Requests
{
    public class ServiceRequest
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public int Discount { get; set; }

        public int Duration { get; set; }

        public bool Enabled { get; set; }
    }
}
