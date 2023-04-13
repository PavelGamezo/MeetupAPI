using AutoMapper;
using Meetup.BusinessLayer.Dtos;
using Meetup.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BusinessLayer.Services.Meetings
{
    public class MeetingMapProfile : Profile
    {
        public MeetingMapProfile()
        {
            CreateMap<MeetingDto, Meeting>().ReverseMap();
        }
    }
}
