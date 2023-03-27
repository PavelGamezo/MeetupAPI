using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BusinessLayer.Dtos
{
    public class MeetingDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Speaker { get; set; }
        public DateTime Date { get; set; }
        public string? Location { get; set; }
    }
}
