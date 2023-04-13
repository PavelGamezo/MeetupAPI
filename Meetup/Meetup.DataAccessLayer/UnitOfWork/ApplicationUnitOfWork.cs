using Meetup.DataAccessLayer.Repositories.Interfaces;
using Meetup.DataAccessLayer.UnitOfWork.Interfaces;
using Meetup.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.DataAccessLayer.UnitOfWork
{
    public class ApplicationUnitOfWork : IUnitOfWork
    {
        private MeetupDbContext _context;

        private UserManager<ApplicationUser> _userManager;
        private IMeetingRepository _meetingRepository;

        public ApplicationUnitOfWork(MeetupDbContext context, UserManager<ApplicationUser> userManager, IMeetingRepository meetingRepository)
        {
            _context = context;
            _userManager = userManager;
            _meetingRepository = meetingRepository;
        }

        public UserManager<ApplicationUser> UserManager => _userManager;

        public IMeetingRepository MeetingRepository => _meetingRepository;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _userManager.Dispose();
                    _meetingRepository.Dispose();
                }
                disposed = true;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
