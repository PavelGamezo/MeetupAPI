using AutoMapper;
using Meetup.BusinessLayer.Dtos;
using Meetup.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BusinessLayer.Services.User
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
        }
    }
}
