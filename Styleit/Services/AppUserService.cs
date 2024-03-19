using Microsoft.AspNetCore.Identity.Data;
using Styleit.Data.Request;
using Styleit.Data.Response;
using Styleit.Model;

namespace Styleit.Services
{
    public interface AppUserService
    {
        Task<BasicResponse> confirmOtp(int otpCode);
        Task<BasicResponse> registerUser(RegistrationRequest request);
        Task<BasicResponse> resendOtp(String email, string purpose);
        Task<BasicResponse> sendcode(AppUser appUser, String purpose);
    }
}
