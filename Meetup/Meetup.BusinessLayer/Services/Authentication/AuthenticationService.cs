using Meetup.BusinessLayer.Interfaces;
using Meetup.DataAccessLayer.Authentication.Interfaces;
using Meetup.DataAccessLayer.UnitOfWork.Interfaces;
using Meetup.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BusinessLayer.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationService (IJwtTokenGenerator jwtTokenGenerator,
            IUnitOfWork unitOfWork)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthenticationResult> Login(string userName, string email, string password)
        {
            // 1. Generate JwtToken
            var token = _jwtTokenGenerator.GenerateToken(userName);

            return new AuthenticationResult
            {
                UserName = userName,
                Email = email,
                Token = token
            };
        }

        public async Task<AuthenticationResult> Register(string userName, string email, string password)
        {
            // 1. Create user
            var user = new ApplicationUser()
            {
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userName
            };

            var result = await _unitOfWork.UserManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new Exception("User creation failed! Please check user details and try again.");
            }

            // 2. Generate JwtToken
            var token = _jwtTokenGenerator.GenerateToken(userName);

            return new AuthenticationResult
            {
                UserName = userName,
                Email = email,
                Token = token
            };
        }
    }
}
