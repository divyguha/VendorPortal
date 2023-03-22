//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VendorApi.Domain.Auth;
using VendorApi.Domain.Common;
using VendorApi.Domain.Entities;
using VendorApi.Domain.Enum;
using VendorApi.Domain.Settings;
using VendorApi.Persistence;
using VendorApi.Service.Contract;
using VendorApi.Service.Exceptions;

namespace VendorApi.Service.Implementation
{
    public class AccountService : IAccountService
    {
        // private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JWTSettings _jwtSettings;
        private readonly IEmailService _emailService;   
        private readonly IDateTimeService _dateTimeService;
        private readonly IFeatureManager _featureManager;
        private readonly IApplicationDbContext _context;
        //private readonly IConfiguration _configuration;
        public AccountService(
                        //UserManager<ApplicationUser> userManager,
                        //RoleManager<IdentityRole> roleManager,
                        //,IConfiguration configuration
                        IOptions<JWTSettings> jwtSettings,
                        //SignInManager<ApplicationUser> signInManager,
                        IDateTimeService dateTimeService,
                        IEmailService emailService,
                        IFeatureManager featureManager,
                        IApplicationDbContext context
                        
                       )
        {
            //_userManager = userManager;
            //_roleManager = roleManager;
            //_configuration = configuration;
            //_signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
            _dateTimeService = dateTimeService;
            _emailService = emailService;
            _featureManager = featureManager;
            _context = context;
            
        }


        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
             var result = await _context.User.FirstOrDefaultAsync(x => x.UserEmail == request.UserEmail && x.password == request.Password);

            if (result == null)
            {
                throw new ApiException($"Invalid Credentials for '{request.UserEmail}'.");
            }
            if (result.Disabled == 1)
            {
                throw new ApiException($"User : '{request.UserEmail}' Disabled . Please contact Administrator");
            }
            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(result.UserId.ToString(),result.UserName,result.UserEmail);
            AuthenticationResponse response = new AuthenticationResponse();
            response.UserId = result.UserId;    
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = result.UserEmail;
            response.UserName = result.UserName;
            response.UserType = result.UserType;
            //response.RegisterLoginDate = result.RegisterLoginDate;
            //var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            //response.Roles = rolesList.ToList();
            response.Roles = null;
            if (result.UserEmail != null)
            {
                response.IsVerified = true;
            }
            var refreshToken = GenerateRefreshToken(ipAddress);
            response.RefreshToken = refreshToken.Token;
            return new Response<AuthenticationResponse>(response, $"Authenticated {result.UserEmail}");
        }


        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            var userWithSameEmail = await _context.User.FirstOrDefaultAsync(x => x.UserEmail == request.Email );
            if (userWithSameEmail != null)
            {
                throw new ApiException($"User Email '{request.Email}' is already Exits.");
            }
            if (userWithSameEmail == null)
            {
                var user = new User();
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.UserName = request.UserName;
                user.password = request.Password;
                if (request.UserType == 1)
                {
                    user.UserType = (int)UserType.SuperAdmin;
                }
                  else if (request.UserType == 2)
                {
                    user.UserType = (int)UserType.Admin;
                }
                else if (request.UserType == 3)
                {
                    user.UserType = (int)UserType.Supplier;
                }
                else if (request.UserType == 4)
                {
                    user.UserType = (int)UserType.ReadOnly;
                }
                user.UserEmail = request.Email;
                user.RegisterLoginDate = _dateTimeService.NowUtc;
                user.LastLoginDate = null;
                _context.User.Add(user);
                await _context.SaveChangesAsync();
            }
            return new Response<string>(message: $"User Registered with Email  {request.Email}");
        }
    

        private async Task<JwtSecurityToken> GenerateJWToken(string userid, string username ,string emailid )
        {
               
            string ipAddress = IpHelper.GetIpAddress();

            var _claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, emailid),
                new Claim("uid", userid),
                new Claim("ip", ipAddress)
            };
            //.Union(userClaims)
            //.Union(roleClaims);
            //var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTSettings:Key")));
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var _signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            //int _duration = _configuration.GetValue<int>("JWTSettings:DurationInMinutes");
            //string _issuer = _configuration.GetValue<string>("JWTSettings:Issuer");
            //string _audience = _configuration.GetValue<string>("JWTSettings:Audience");

            int _duration = (int)_jwtSettings.DurationInMinutes;
            string _issuer = _jwtSettings.Issuer;
            string _audience = _jwtSettings.Audience;

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: _claims,
                expires: DateTime.UtcNow.AddMinutes(_duration),
                signingCredentials: _signingCredentials);
            return  jwtSecurityToken;
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }

        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }


        public async Task ForgotPassword(ForgotPasswordRequest request, string origin)
        {
            var account = await _context.User.FirstOrDefaultAsync(x => x.UserEmail == request.Email); ;
            if (account == null)
            {
                throw new ApiException($"User Email '{request.Email}' doesnot Exits.");
            }
            if (account != null)
            {
                ApplicationUser au = new ApplicationUser();
                au.Email = account.UserEmail;
                au.UserName = account.UserName;
                var code = await GeneratePasswordResetTokenAsync(account);
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(au);
                var route = "api/account/reset-password/";
                var _enpointUri = new Uri(string.Concat($"{origin}/", route));
                var emailRequest = new MailRequest()
                {
                    //Body = $"You reset password link  is - {_enpointUri}",
                    Body = $"You reset token is - {code}",
                    ToEmail = request.Email,
                    Subject = "Reset Password",
                };
                await _emailService.SendEmailAsync(emailRequest);
            }
        }

        private async Task<Response<string>> GeneratePasswordResetTokenAsync(User account)
        {
            if (account == null)
            {
                throw new ApiException($"User Email '{account.UserEmail}' doesnot Exits.");
            }
            if (account != null)
            {
                //account.password = request.Password;
                //account.password = request.ConfirmPassword;
                //_context.Users.Update(account);
                //await _context.SaveChangesAsync();
                ResetPasswordRequest rpr = new ResetPasswordRequest();

                rpr.Email = account.UserEmail;
                rpr.Password = account.password;
                rpr.Token = "";
                return new Response<string>(rpr.Token);

            }
            return new Response<string>(message: $"User Registered with Email  {account.UserEmail}");
        }

        public async Task<Response<string>> ResetPassword(ResetPasswordRequest request)
        {
            var account = await _context.User.FirstOrDefaultAsync(x => x.UserEmail == request.Email); ;
            if (account == null)
            {
                throw new ApiException($"User Email '{request.Email}' doesnot Exits.");
            }
            if (request.Password != request.ConfirmPassword)
            {
                throw new ApiException($"Password & Confrim Password Doesnot Match for Email '{request.Email}'");
            }

            if (account != null)
            {
                account.password = request.Password;
                account.password = request.ConfirmPassword;
                _context.User.Update(account);
                await _context.SaveChangesAsync();
            }
            return new Response<string>(message: $"User Registered with Email  {request.Email}");
        }
    }

}



//public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
//{
//    var user = await _userManager.FindByEmailAsync(request.UserEmail);
//    if (user == null)
//    {
//        throw new ApiException($"No Accounts Registered with {request.UserEmail}.");
//    }
//    var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
//    if (!result.Succeeded)
//    {
//        throw new ApiException($"Invalid Credentials for '{request.UserEmail}'.");
//    }
//    if (!user.EmailConfirmed)
//    {
//        throw new ApiException($"Account Not Confirmed for '{request.Email}'.");
//    }
//    JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
//    AuthenticationResponse response = new AuthenticationResponse();
//    response.Id = user.Id;
//    response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
//    response.Email = user.Email;
//    response.UserName = user.UserName;
//    var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
//    response.Roles = rolesList.ToList();
//    response.IsVerified = user.EmailConfirmed;
//    var refreshToken = GenerateRefreshToken(ipAddress);
//    response.RefreshToken = refreshToken.Token;
//    return new Response<AuthenticationResponse>(response, $"Authenticated {user.UserName}");
//}


//public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
//{
//    var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
//    if (userWithSameUserName != null)
//    {
//        throw new ApiException($"Username '{request.UserName}' is already taken.");
//    }
//    var user = new ApplicationUser
//    {
//        Email = request.Email,
//        FirstName = request.FirstName,
//        LastName = request.LastName,
//        UserName = request.UserName
//    };
//    var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
//    if (userWithSameEmail == null)
//    {
//        var result = await _userManager.CreateAsync(user, request.Password);
//        if (result.Succeeded)
//        {
//            await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());
//            var verificationUri = await SendVerificationEmail(user, origin);

//            if (await _featureManager.IsEnabledAsync(nameof(FeatureManagement.EnableEmailService)))
//            {
//              //  await _emailService.SendEmailAsync(new MailRequest() { From = "amit.naik8103@gmail.com", ToEmail = user.Email, Body = $"Please confirm your account by visiting this URL {verificationUri}", Subject = "Confirm Registration" });
//            }
//            return new Response<string>(user.Id, message: $"User Registered. Please confirm your account by visiting this URL {verificationUri}");
//        }
//        else
//        {
//            throw new ApiException($"{result.Errors.ToList()[0].Description}");
//        }
//    }
//    else
//    {
//        throw new ApiException($"Email {request.Email } is already registered.");
//    }
//}

//private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
//{
//    var userClaims = await _userManager.GetClaimsAsync(user);
//    var roles = await _userManager.GetRolesAsync(user);

//    var roleClaims = new List<Claim>();

//    for (int i = 0; i < roles.Count; i++)
//    {
//        roleClaims.Add(new Claim("roles", roles[i]));
//    }

//    string ipAddress = IpHelper.GetIpAddress();

//    var claims = new[]
//    {
//        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
//        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//        new Claim(JwtRegisteredClaimNames.Email, user.Email),
//        new Claim("uid", user.Id),
//        new Claim("ip", ipAddress)
//    }
//    .Union(userClaims)
//    .Union(roleClaims);

//    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
//    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

//    var jwtSecurityToken = new JwtSecurityToken(
//        issuer: _jwtSettings.Issuer,
//        audience: _jwtSettings.Audience,
//        claims: claims,
//        expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
//        signingCredentials: signingCredentials);
//    return jwtSecurityToken;
//}

//private async Task<string> SendVerificationEmail(ApplicationUser user, string origin)
//{
//    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
//    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
//    var route = "api/account/confirm-email/";
//    var _enpointUri = new Uri(string.Concat($"{origin}/", route));
//    var verificationUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "userId", user.Id);
//    verificationUri = QueryHelpers.AddQueryString(verificationUri, "code", code);
//    //Email Service Call Here
//    return verificationUri;
//}



//public async Task<Response<string>> ConfirmEmailAsync(string userId, string code)
//{
//    var user = await _userManager.FindByIdAsync(userId);
//    code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
//    var result = await _userManager.ConfirmEmailAsync(user, code);
//    if (result.Succeeded)
//    {
//        return new Response<string>(user.Id, message: $"Account Confirmed for {user.Email}. You can now use the /api/Account/authenticate endpoint.");
//    }
//    else
//    {
//        throw new ApiException($"An error occured while confirming {user.Email}.");
//    }
//}


//public async Task ForgotPassword(ForgotPasswordRequest model, string origin)
//{
//    var account = await _userManager.FindByEmailAsync(model.Email);

//    // always return ok response to prevent email enumeration
//    if (account == null) return;

//    var code = await _userManager.GeneratePasswordResetTokenAsync(account);
//    var route = "api/account/reset-password/";
//    var _enpointUri = new Uri(string.Concat($"{origin}/", route));
//    //var emailRequest = new MailRequest()
//    //{
//    //    Body = $"You reset token is - {code}",
//    //    ToEmail = model.Email,
//    //    Subject = "Reset Password",
//    //};
//    //await _emailService.SendEmailAsync(emailRequest);
//}

//public async Task<Response<string>> ResetPassword(ResetPasswordRequest model)
//{
//    var account = await _userManager.FindByEmailAsync(model.Email);
//    if (account == null) throw new ApiException($"No Accounts Registered with {model.Email}.");
//    var result = await _userManager.ResetPasswordAsync(account, model.Token, model.Password);
//    if (result.Succeeded)
//    {
//        return new Response<string>(model.Email, message: $"Password Resetted.");
//    }
//    else
//    {
//        throw new ApiException($"Error occured while reseting the password.");
//    }
//}