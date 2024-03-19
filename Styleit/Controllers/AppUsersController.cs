using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Styleit;
using Styleit.Data.Request;
using Styleit.Data.Response;
using Styleit.Model;
using Styleit.Services;

namespace Styleit.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
       private readonly AppUserService _userService;

        public AppUsersController(AppUserService userService)
        {
            this._userService = userService;
        }



        // GET: api/AppUsers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<AppUser>>> GetAppUsers()
        //{
        //    return await _context.AppUsers.ToListAsync();
        //}

        //// GET: api/AppUsers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<AppUser>> GetAppUser(int id)
        //{
        //    var appUser = await _context.AppUsers.FindAsync(id);

        //    if (appUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return appUser;
        //}

        // PUT: api/AppUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAppUser(int id, AppUser appUser)
        //{
        //    if (id != appUser.AppUserId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(appUser).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AppUserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/AppUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("register")]
        public async Task<BasicResponse> PostAppUser(RegistrationRequest request)
        {
            return await _userService.registerUser(request);
        }
        [HttpGet("confirm-otp")]
        public async Task<BasicResponse> ConfirmOtp([FromQuery] int otpCode)
        {
            return await _userService.confirmOtp(otpCode);
        }
        [HttpGet("resend-otp/{email}")]
        public async Task<BasicResponse> ResendOtp(String email, [FromQuery] string purpose)
        {
            return await _userService.resendOtp(email, purpose);
        }

        // DELETE: api/AppUsers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAppUser(int id)
        //{
        //    var appUser = await _context.AppUsers.FindAsync(id);
        //    if (appUser == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.AppUsers.Remove(appUser);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AppUserExists(int id)
        //{
        //    return _context.AppUsers.Any(e => e.AppUserId == id);
        //}
    }
}
