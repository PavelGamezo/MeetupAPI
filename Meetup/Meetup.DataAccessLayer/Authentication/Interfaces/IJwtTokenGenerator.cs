using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.DataAccessLayer.Authentication.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string userName);
    }
}
