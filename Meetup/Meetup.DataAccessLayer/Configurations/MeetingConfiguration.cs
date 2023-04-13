using Meetup.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.DataAccessLayer.Configurations
{
    public class MeetingConfigurations : IEntityTypeConfiguration<Meeting>
    {
        public void Configure(EntityTypeBuilder<Meeting> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Title)
                   .IsRequired();

            builder.Property(q => q.Description)
                   .IsRequired();

            builder.Property(q => q.Speaker)
                   .IsRequired();

            builder.Property(q => q.Date)
                   .IsRequired();
        }
    }
}
