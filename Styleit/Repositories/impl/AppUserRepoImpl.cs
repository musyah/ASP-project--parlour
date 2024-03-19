using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Styleit.Model;

namespace Styleit.Repositories.impl
{
    public class AppUserRepoImpl : AppUserRepo
    {
        private readonly ApplicationDbContext _context;

        public AppUserRepoImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser> getUser(string email)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(e => e.Email == email);
        }
        public async Task<bool> FindByEmail(string email)
        {
            return  _context.AppUsers.Any(e => e.Email == email);
        }

        public bool FindById(int id)
        {
            return _context.AppUsers.Any(e => e.AppUserId == id);
        }

        public async Task<bool> SaveUser(AppUser appUser)
        {
            _context.AppUsers.Add(appUser);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUser(AppUser appUser)
        {
            _context.Entry(appUser).State = EntityState.Modified;
            return await _context.SaveChangesAsync()> 0;
        }

        public async Task<AppUser> getUser(int id)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(e => e.AppUserId == id);
        }
    }
}
