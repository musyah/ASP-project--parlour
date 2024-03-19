using Styleit.Model;

namespace Styleit.Repositories
{
    public interface AppUserRepo
    {
        Task<AppUser> getUser(string email);
        Task<bool> FindByEmail(string email);
        Boolean FindById(int id);
        Task<AppUser> getUser(int id);
        Task<bool> SaveUser(AppUser appUser);
        Task<bool> UpdateUser(AppUser appUser);

    }
}
