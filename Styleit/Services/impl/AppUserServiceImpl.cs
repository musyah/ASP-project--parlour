using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Styleit.Data.Response;
using Styleit.Model;
using Styleit.Repositories;
using System.ComponentModel.DataAnnotations;
using Styleit.Data.Request;
using Styleit.Utils;
using Org.BouncyCastle.Crypto.Generators;
namespace Styleit.Services.impl;

public class AppUserServiceImpl : AppUserService

{
    private readonly AppUserRepo _userRepo;
    private readonly Emailsend _emailSend;
    private readonly OtpsRepo _otpsRepo;

    public AppUserServiceImpl(AppUserRepo userRepo, Emailsend emailsend, OtpsRepo otpsRepo)
    {
        this._userRepo = userRepo;
        this._emailSend = emailsend;
        this._otpsRepo = otpsRepo;
    }

    public async Task<BasicResponse> confirmOtp(int otpCode)
    {
        if (!await _otpsRepo.FindByCode(otpCode))
        {
            return BasicResponse.ofFailure("Otp does not exist");
        }

        Otps otp = await _otpsRepo.getOtpObject(otpCode);
        if (otp.Expiry < DateTime.UtcNow)
        {
            return BasicResponse.ofFailure("Otp has expired");
        }
        AppUser appUser = otp.AppUser;
        if (!await _userRepo.UpdateUser(appUser))
        {
            return BasicResponse.ofFailure("Failed to confirm "+otp.Purpose+" otp");
        }
        return BasicResponse.ofSuccess(otp.Purpose+" otp confirmed succesfully",null);
    }

    public async Task<BasicResponse> registerUser(RegistrationRequest request)
    {
        if (await _userRepo.FindByEmail(request.Email))
        {
            return BasicResponse.ofFailure("user exists");
        }

        AppUser appUser = new AppUser(
            request.Email,
            request.FirstName,
            request.LastName,
            request.UserRole,
            BCrypt.Net.BCrypt.HashPassword(request.Password));
        if (await _userRepo.SaveUser(appUser))
        {
            return await sendcode(appUser, "verification");
        }
        return BasicResponse.ofFailure("An error occurred");
    }

    public async Task<BasicResponse> resendOtp(string email, string purpose)
    {
        if (!await _userRepo.FindByEmail(email))
        {
            return BasicResponse.ofFailure("User with email does not exist");
        }
        AppUser user = await _userRepo.getUser(email);
        return await sendcode(user, purpose);
    }

    public async Task<BasicResponse> sendcode(AppUser appUser, String purpose)
    {
        int code = GenerateRandomNo();
        Otps otp = new Otps(
           code,
            DateTime.Now.AddMinutes(15),
            purpose,
            appUser
        );
        String message = "Hello "+appUser.FirstName+" your " + purpose + " otp is " + code;
        if (await _otpsRepo.SaveOtp(otp))
        {
            _emailSend.send(appUser.Email, message);
            return BasicResponse.ofSuccess(null);
        }
        return BasicResponse.ofFailure("Error in generating otp");
    }
    private int GenerateRandomNo()
    {
        int _min = 1000;
        int _max = 9999;
        Random _rdm = new Random();
        return _rdm.Next(_min, _max);
    }


}

