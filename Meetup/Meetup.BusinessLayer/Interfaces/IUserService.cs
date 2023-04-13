using Meetup.BusinessLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        //Task<IReadOnlyCollection<UserDto>> GetAll();

        Task<UserDto> GetUserById(string id);

        Task<UserDto> GetUserByName(string userName);

        Task<UserDto> GetUserByEmail(string email);

        Task<bool> CheckPassword(string email, string password);

        Task<bool> IsExist(string email, string password, string userName);

        Task AddUser(UserDto userDto);
    }
}
