using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.DataAccessLayer.Authentication
{
    public class JwtSettings
    {
        public string ValidAudience { get; set; } = null!;
        public string ValidIssuer { get; set; } = null!;
        public string Secret { get; set; } = null!;
    }
}
