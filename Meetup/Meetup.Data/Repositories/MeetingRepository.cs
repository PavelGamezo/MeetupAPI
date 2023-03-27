using Meetup.Data.Repositories.Interfaces;
using Meetup.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Data.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private bool disposed = false;
        private readonly ApplicationDbContext _context;

        public MeetingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Meeting entity)
        {
            await _context.Meetings.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);

            if(entity is null)
            {
                return;
            }

            _context.Remove(entity);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<Meeting> GetAll()
        {
            return _context.Meetings.AsQueryable();
        }

        public async Task<Meeting> GetById(Guid id)
        {
            return await _context.Meetings.FindAsync(id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Guid id, Meeting entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
