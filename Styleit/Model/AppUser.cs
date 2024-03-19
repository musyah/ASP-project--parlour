using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Styleit.Model
{
    public class AppUser
    {
        [Key]
        public int AppUserId { get; set; }
      
        public String Email { get; set; }
        public String FirstName { get; set; } = "";
        public String LastName { get; set; } = "";
        public Role UserRole { get; set; } = Role.CUSTOMER.ToString();
        public String Password { get; set; }
        public Boolean Enabled { get; set; } = false;

        public AppUser()
        {
        }


        public AppUser(string email, string firstName, string lastName, Role userRole, string password)
        {
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserRole = userRole;
            this.Password = password;
        }
        
    }
}
