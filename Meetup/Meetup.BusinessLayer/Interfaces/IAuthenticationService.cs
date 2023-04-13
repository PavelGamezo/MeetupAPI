using Meetup.BusinessLayer.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BusinessLayer.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> Login(string userName, string email, string password);
        Task<AuthenticationResult> Register(string userName, string email, string password);
    }
}
