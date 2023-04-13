using AutoMapper;
using AutoMapper.QueryableExtensions;
using Meetup.BusinessLayer.Dtos;
using Meetup.BusinessLayer.Interfaces;
using Meetup.DataAccessLayer.Repositories.Interfaces;
using Meetup.Domain.Entities;
using Meetup.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BusinessLayer.Services.Meetings
{
    public class MeetingService : IMeetingService
    {
        private readonly IMapper _mapper;
        private readonly IMeetingRepository _meetingRepository;

        public MeetingService(IMeetingRepository meetingRepository, IMapper mapper)
        {
            _mapper = mapper;
            _meetingRepository = meetingRepository;
        }

        public async Task<IReadOnlyCollection<MeetingDto>> GetMeetings()
        {
            return await _meetingRepository.GetAll()
                                           .ProjectTo<MeetingDto>(_mapper.ConfigurationProvider)
                                           .ToArrayAsync();
        }

        public async Task<MeetingDto> GetMeeting(Guid id)
        {
            var meeting = await _meetingRepository.GetById(id);
            return _mapper.Map<MeetingDto>(meeting);
        }

        public async Task<MeetingDto> AddMeeting(MeetingDto meetingDto)
        {
            if (await _meetingRepository.GetAll().AnyAsync(q => q.Title == meetingDto.Title))
            {
                throw new ObjectExistException(meetingDto.Title);
            }

            var meetingEntity = _mapper.Map<Meeting>(meetingDto);
            await _meetingRepository.Add(meetingEntity);

            await _meetingRepository.Save();

            return _mapper.Map<MeetingDto>(meetingEntity);
        }

        public async Task<MeetingDto> UpdateMeeting(Guid id, MeetingDto meetingDto)
        {
            var meetingEntity = await _meetingRepository.GetById(id);
            if (meetingEntity is null)
            {
                throw new ObjectNotFoundException("Meeting");
            }

            _mapper.Map(meetingDto, meetingEntity);

            await _meetingRepository.Save();

            return _mapper.Map<MeetingDto>(meetingEntity);
        }

        public async Task DeleteMeeting(Guid id)
        {
            await _meetingRepository.Delete(id);
            await _meetingRepository.Save();
        }
    }
}
