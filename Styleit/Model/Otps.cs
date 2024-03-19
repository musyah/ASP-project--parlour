using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Styleit.Model
{
    public class Otps
    {
        [Key]
        public int VerificationCode { get; set; }
        public DateTime Expiry { get; set; }
        public String Purpose { get; set; } = "";
        [ForeignKey("AppUser")]
        public int AppUserId { get; set; }

        // Navigation property
        public virtual AppUser AppUser { get; set; }

        public Otps()
        {
        }

        public Otps(int verificationCode, DateTime expiry, string purpose, AppUser appuser)
        {
            this.VerificationCode = verificationCode;
            this.Expiry = expiry;
            this.Purpose = purpose;
            this.AppUserId = appuser.AppUserId;
        }

        }
    }
