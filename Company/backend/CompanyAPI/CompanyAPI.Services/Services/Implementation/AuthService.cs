using CompanyAPI.Domain.Models;
using CompanyAPI.Domain.ValueObjects;
using CompanyAPI.Domain.ViewModel;
using CompanyAPI.Repository.Interfaces;
using CompanyAPI.Services.Interfaces;
using CompanyAPI.Shared.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ApplicationSettings _appSettings;

        public AuthService(IAuthRepository authRepository, IOptions<ApplicationSettings> settings)
        {
            _authRepository = authRepository;
            _appSettings = settings.Value;
        }

        private async Task<string> GenerateToken(string userName)
        {
            var user = await _authRepository.FindUserByUserName(userName);

            //var identityClaims = await _authRepository.GetUserClaims(user);

            var key = Encoding.UTF8.GetBytes(_appSettings.JWT_Secret);

            var securityKey = new SymmetricSecurityKey(key);

            var credentials = new SigningCredentials(securityKey,
                            Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Subject = identityClaims,
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience,
                Expires = DateTime.UtcNow.AddHours(_appSettings.Expires),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<LoginUser> Login(LoginViewModel user)
        {
            try
            {
                string token = await GenerateToken(user.UserName);

                return new LoginUser
                {
                    Employee = null,
                    Token = token,
                    Role = string.Empty
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IdentityResult> Register(UserViewModel user)
        {
            try
            {
                return await _authRepository.CreateUser(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UserExists(string UserName)
        {
            try
            {
                return await _authRepository.UserExists(UserName);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<SignInResult> UserSignIn(LoginViewModel login)
        {
            try
            {
                return await _authRepository.SignIn(login);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<bool> EmailExists(string Email)
        {
            return await _authRepository.EmailExists(Email);
        }
    }
}
