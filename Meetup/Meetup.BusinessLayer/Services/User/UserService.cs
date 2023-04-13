using AutoMapper;
using Meetup.BusinessLayer.Dtos;
using Meetup.BusinessLayer.Interfaces;
using Meetup.DataAccessLayer.UnitOfWork.Interfaces;
using Meetup.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BusinessLayer.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            _database = uow;
            _mapper = mapper;
        }

        public async Task AddUser(UserDto userDto)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);
            await _database.UserManager.CreateAsync(user, userDto.Password);
        }

        //public Task<IReadOnlyCollection<UserDto>> GetAll()
        //{
        //    throw new Exception();
        //}

        public async Task<UserDto> GetUserById(string id)
        {
            var user = await _database.UserManager.FindByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByName(string userName)
        {
            var user = await _database.UserManager.FindByNameAsync(userName);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> CheckPassword(string email, string password)
        {
            var user = await _database.UserManager.FindByEmailAsync(email);
            return await _database.UserManager.CheckPasswordAsync(user, password);
        }

        public async Task<bool> IsExist(string email, string password, string userName)
        {
            var user = await _database.UserManager.FindByEmailAsync(email);
            if (user is null && await CheckPassword(email, password) == false && await GetUserByName(userName) == null)
            {
                return false;
            }

            return true;
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var user = await _database.UserManager.FindByEmailAsync(email);
            return _mapper.Map<UserDto>(user);
        }
    }
}
