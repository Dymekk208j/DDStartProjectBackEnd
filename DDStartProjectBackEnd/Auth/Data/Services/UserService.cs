using DDStartProjectBackEnd.Auth.Data.Services.Interfaces;
using DDStartProjectBackEnd.Auth.Dto.Requests;
using DDStartProjectBackEnd.Auth.Dto.Responses;
using DDStartProjectBackEnd.Auth.Models;
using DDStartProjectBackEnd.Common.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.Auth.Data.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;

        public UserService(UserManager<User> userManager, JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }

        public async Task<IsEmailAvailableResponse> IsEmailAvailable(IsEmailAvailableRequest request)
        {
            return new IsEmailAvailableResponse()
            {
                IsEmailAvailable = await _userManager.FindByEmailAsync(request.Email) == null
            };
        }

        public async Task<IsUsernameAvailableResponse> IsUsernameAvailable(IsUsernameAvailableRequest request)
        {
            var response = new IsUsernameAvailableResponse()
            {
                IsUserNameAvailable = await _userManager.FindByNameAsync(request.Username) == null
            };

            return response;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            request.Login = request.Login.Trim();
            request.Password = request.Password.Trim();

            var user = await _userManager.FindByNameAsync(request.Login);

            if (user == null)
                user = await _userManager.FindByEmailAsync(request.Login);


            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return null;
            }

            var claims = new List<Claim>();

            //if (user.IsAdmin)
            //{
            //    claims.Add(new Claim("can_delete", "true"));
            //    claims.Add(new Claim("can_view", "true"));
            //}

            var key = new SymmetricSecurityKey(_jwtSettings.Key);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: request.RememberMe ? null : DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );


            var response = new LoginResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Login = request.Login,
                Id = user.Id,
                RememberMe = request.RememberMe
            };


            return response;
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            RegisterResponse response = new RegisterResponse()
            {
                Errors = new List<string>(),
                IsSuccess = false
            };

            try
            {
                if (string.IsNullOrEmpty(request.Email)
                    || string.IsNullOrEmpty(request.EmailConfirm)
                    || string.IsNullOrEmpty(request.Password)
                    || string.IsNullOrEmpty(request.PasswordConfirm))
                    throw new RegistrationProblemException("wrong.model");

                request.Email = request.Email.Trim();
                request.EmailConfirm = request.EmailConfirm.Trim();
                request.Password = request.Password.Trim();
                request.PasswordConfirm = request.PasswordConfirm.Trim();

                if (string.Compare(request.Email, request.EmailConfirm) != 0) throw new RegistrationProblemException("emails.do.not.match");
                if (string.Compare(request.Password, request.PasswordConfirm) != 0) throw new RegistrationProblemException("passwords.do.not.match");

                var isUserNameAvaiable = await _userManager.FindByNameAsync(request.UserName);
                var isEmailAvaiable = await _userManager.FindByEmailAsync(request.Email);

                if (isUserNameAvaiable != null || isEmailAvaiable != null) throw new RegistrationProblemException("user.exist");

                var user = new User()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    Firstname = request.FirstName,
                    Lastname = request.LastName,
                    Gender = request.Gender
                };

                var createAccountResult = await _userManager.CreateAsync(user, request.Password);

                if (createAccountResult.Errors.Any())
                    createAccountResult.Errors.ToList().ForEach(er => { response.Errors.Add(er.Description); });

                response.IsSuccess = createAccountResult.Succeeded;

                return response;
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccess = false;
                return response;
            }
        }
    }
}
