using Microsoft.CodeAnalysis.CSharp.Syntax;
using Styleit.Model;
using System.ComponentModel.DataAnnotations;
namespace Styleit.Data.Request
{
    public class RegistrationRequest
    {

        public  String Email { get; set; }
        public string FirstName { get; set; }
        public String LastName { get; set; }
        public String Password { get; set; }

        public Role UserRole { get; set; }
       
        public RegistrationRequest(string email, string firstName, string lastName, Role userRole, string password)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            UserRole = userRole;
            Password = password;
        }

        public Boolean isOkay()
        {
            return !string.IsNullOrEmpty(this.Email) &&
               this.UserRole != null &&
               !string.IsNullOrEmpty(this.Password);

        }
        
    }

}
