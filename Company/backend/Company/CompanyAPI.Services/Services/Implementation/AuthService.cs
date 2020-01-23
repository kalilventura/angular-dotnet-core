using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using CompanyAPI.Domain.Models;
using CompanyAPI.Domain.ViewModel;
using CompanyAPI.Repository.Interfaces;
using CompanyAPI.Services.Interfaces;
using CompanyAPI.Shared.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CompanyAPI.Services.Implementation
{
    public class AuthService : IAuthService
    {
        readonly IAuthRepository _authRepository;
        readonly ApplicationSettings _appSettings;

        public AuthService(IAuthRepository authRepository,
                           IOptions<ApplicationSettings> settings)
        {
            _authRepository = authRepository;
            _appSettings = settings.Value;
        }

        private async Task<string> GenerateToken(string username)
        {
            var user = await _authRepository.FindUserByUserName(username);

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

        public async Task<User> Login(Login user)
        {
            try
            {
                string token = await GenerateToken(user.Username);

                var loginUser = await _authRepository.FindUserByUserName(user.Username);

                return new User
                {
                    Email = loginUser.Email,
                    UserName = loginUser.UserName,
                    FullName = loginUser.FullName,
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

        public async Task<IdentityResult> Register(Register user)
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

        public async Task<SignInResult> UserSignIn(Login login)
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