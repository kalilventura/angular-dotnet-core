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

        private async Task<string> GenerateToken(string email)
        {
            var user = await _authRepository.FindUserByEmail(email);

            var identityClaims = await _authRepository.GetUserClaims(user);

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.JWT_Secret);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,

                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience,
                Expires = DateTime.UtcNow.AddHours(_appSettings.Expires),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        public async Task<LoginUser> login(UserViewModel user)
        {
            try
            {
                string token = string.Empty;
                bool userExists = await _authRepository.userExists(user);

                if (!userExists)
                    throw new Exception("User not exists");

                var result = await _authRepository.SignIn(user);

                if (result.Succeeded)
                    token = await GenerateToken(user.Email);
                else
                    throw new Exception("Forbidden");

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

        public async Task<IdentityResult> register(UserViewModel user)
        {
            try
            {
                bool userExists = await _authRepository.userExists(user);

                if (userExists)
                    throw new Exception("User exists");

                var result = await _authRepository.CreateUser(user);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
