using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Styleit.Model;

namespace Styleit.Repositories.impl
{
    public class OtpsRepoImpl : OtpsRepo
    {
        private readonly ApplicationDbContext _context;
        public OtpsRepoImpl(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> FindByCode(int code)
        {
            return _context.OtpInfo.Any(e => e.VerificationCode == code);
        }

        public async Task<Otps> getOtpObject(int code)
        {
            return await _context.OtpInfo.FirstOrDefaultAsync(e => e.VerificationCode == code);
        }

        public async Task<bool> SaveOtp(Otps otp)
        {
            _context.OtpInfo.Add(otp);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
