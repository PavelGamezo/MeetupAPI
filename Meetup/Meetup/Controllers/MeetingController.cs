using Meetup.BusinessLayer.Dtos;
using Meetup.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetupAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet]
        [Authorize]
        public Task<IReadOnlyCollection<MeetingDto>> GetEvents()
        {
            return _meetingService.GetMeetings();
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public Task<MeetingDto> GetEvent([FromRoute] Guid id)
        {
            return _meetingService.GetMeeting(id);
        }

        [HttpPost]
        [Authorize]
        public Task<MeetingDto> AddEvent([FromBody] MeetingDto meetingDto)
        {
            return _meetingService.AddMeeting(meetingDto);
        }

        [HttpPost("by-form")]
        [Authorize]
        public Task<MeetingDto> AddEventByFormData([FromBody] MeetingDto meetingDto)
        {
            return _meetingService.AddMeeting(meetingDto);
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        public Task<MeetingDto> UpdateEvent([FromRoute] Guid id, [FromBody] MeetingDto meetingDto)
        {
            return _meetingService.UpdateMeeting(id, meetingDto);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public Task DeleteUser([FromRoute] Guid id)
        {
            return _meetingService.DeleteMeeting(id);
        }
    }
}
