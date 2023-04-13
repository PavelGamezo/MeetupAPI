using Meetup.DataAccessLayer.Configurations;
using Meetup.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.DataAccessLayer
{
    public class MeetupDbContext : IdentityDbContext<ApplicationUser>
    {
        public MeetupDbContext(DbContextOptions<MeetupDbContext> options) : base(options)
        {
        }

        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MeetingConfigurations());
        }
    }
}
