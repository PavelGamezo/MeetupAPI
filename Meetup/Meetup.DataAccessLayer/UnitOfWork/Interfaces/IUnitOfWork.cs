using Meetup.DataAccessLayer.Repositories.Interfaces;
using Meetup.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.DataAccessLayer.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        UserManager<ApplicationUser> UserManager { get; }
        IMeetingRepository MeetingRepository { get; }

        Task SaveAsync();
    }
}
