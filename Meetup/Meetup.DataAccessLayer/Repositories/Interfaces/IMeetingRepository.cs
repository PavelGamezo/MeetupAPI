using Meetup.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.DataAccessLayer.Repositories.Interfaces
{
    public interface IMeetingRepository : IBaseRepository<Meeting>
    {
    }
}
