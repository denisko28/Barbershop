using System.Threading.Tasks;
using Barbershop.BLL.DTO.Requests;
using Barbershop.BLL.DTO.Responses;

namespace Barbershop.BLL.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<bool> SignInAsync(UserSignInRequest request);

        Task<int> SignUpAsync(CustomerSignUpRequest request);
    }
}
