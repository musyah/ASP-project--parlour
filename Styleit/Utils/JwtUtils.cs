using Realms.Sync;

namespace Styleit.Utils
{
    public interface JwtUtils
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
    }
}
