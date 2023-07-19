using Library.Domain.Dto;
using Library.Domain.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Services.Interfaces
{
    public interface IUserServices
    {
        Task<bool> Insert(AddUserDto add);
        List<GetUserDto> GetAll();

        GetUserDto Get(int idUser);

        TokenDto Login(LoginDto user);

        Task<bool> Delete(int id);
        Task<bool> UpdatePassword(UserPasswordDto password, int idUser);
    }
}
