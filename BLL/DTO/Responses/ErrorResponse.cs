using System.Collections.Generic;

namespace Barbershop.BLL.DTO.Responses
{
    public class ErrorResponse
    {
        public List<string> Errors { get; } = new List<string>();

        public ErrorResponse(string error) =>
            Errors = new List<string>()
            {
                error
            };

        public ErrorResponse()
        {
        }
    }
}
