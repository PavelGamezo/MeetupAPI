using Meetup.BusinessLayer.Dtos;
using Meetup.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetMeetings()
        {
            var meetings = await _meetingService.GetMeetings();
            if (meetings == null)
            {
                return NotFound();
            }

            return Ok(meetings);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetMeeting([FromRoute] Guid id)
        {
            var meeting = await _meetingService.GetMeeting(id);
            if (meeting is null)
            {
                return NotFound();
            }

            return Ok(meeting);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddMeeting([FromBody] MeetingDto meetingDto)
        {
            var addedMeeting = await _meetingService.AddMeeting(meetingDto);
            if (addedMeeting is null)
            {
                return BadRequest();
            }

            return Ok(addedMeeting);
        }

        [HttpPost("by-form")]
        [Authorize]
        public async Task<IActionResult> AddMeetingByFormData([FromBody] MeetingDto meetingDto)
        {
            var addedMeeting = await _meetingService.AddMeeting(meetingDto);
            if (addedMeeting is null)
            {
                return BadRequest();
            }

            return Ok(addedMeeting);
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> UpdateMeeting([FromRoute] Guid id, [FromBody] MeetingDto meetingDto)
        {
            var updatedMeeting = await _meetingService.UpdateMeeting(id, meetingDto);
            if (updatedMeeting is null)
            {
                return BadRequest(meetingDto);
            }

            return Ok(updatedMeeting);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteMeeting([FromRoute] Guid id)
        {
            var meeting = await _meetingService.GetMeeting(id);
            if (meeting is null)
            {
                return NotFound();
            }

            await _meetingService.DeleteMeeting(id);

            return Ok();
        }
    }
}
