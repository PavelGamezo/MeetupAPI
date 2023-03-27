using Meetup.BusinessLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BusinessLayer.Interfaces
{
    public interface IMeetingService
    {
        Task<IReadOnlyCollection<MeetingDto>> GetMeetings();

        Task<MeetingDto> GetMeeting(Guid id);

        Task<MeetingDto> AddMeeting(MeetingDto eventDto);

        Task<MeetingDto> UpdateMeeting(Guid id, MeetingDto eventDto);

        Task DeleteMeeting(Guid id);
    }
}
