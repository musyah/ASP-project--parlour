using Styleit.Model;

namespace Styleit.Repositories
{
    public interface OtpsRepo
    {
        Task<bool> FindByCode(int code);
        Task<Otps> getOtpObject(int code);
        Task<bool> SaveOtp(Otps otp);
    }
}
