using Meetup.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Data.Configurations
{
    public class MeetingConfiguration : IEntityTypeConfiguration<Meeting>
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

            builder.Property(q=>q.Date)
                   .IsRequired();
        }
    }
}
