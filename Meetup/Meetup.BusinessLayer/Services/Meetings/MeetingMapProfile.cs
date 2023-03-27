using AutoMapper;
using Meetup.BusinessLayer.Dtos;
using Meetup.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BusinessLayer.Services.Events
{
    public class MeetingMapProfile : Profile
    {
        public MeetingMapProfile()
        {
            CreateMap<MeetingDto, Meeting>().ReverseMap();
        }
    }
}
