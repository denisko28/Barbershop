using System;

namespace Barbershop.BLL.DTO.Requests
{
    public class AppointmentRequest
    {
        public int Id { get; set; }

        public int BarberId { get; set; }

        public int CustomerId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public DateTime CreationDate { get; set; }

        public int StatusId { get; set; }
    }
}
