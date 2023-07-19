using Infraestructure.Entity.Models;
using Infraestructure.UnitOfWork.Interface;
using Library.Domain.Dto.User;
using Library.Domain.Dto;
using Library.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Common.Exceptions;
using Common.Resources;
using static Common.Constant.Const;
using Common.Helpers;

namespace Library.Domain.Services
{
    public class UserServices : IUserServices
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public UserServices(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }


        #region authentication

        public TokenDto Login(LoginDto login)
        {
            UserEntity user = _unitOfWork.UserRepository.FirstOrDefault(x => x.UserName == login.UserName,
                                                                          r => r.RoleEntity);
            if (user == null)
                throw new BusinessException(GeneralMessages.Error401);

            string userEnteredPassword = login.Password;
            string hashedPasswordFromDatabase = user.Password;

            if (!Common.Helpers.Utils.VerifyPassword(userEnteredPassword, hashedPasswordFromDatabase))
                throw new BusinessException(GeneralMessages.PasswordIncorrect);

            return GenerateTokenJWT(user);

        }

        public TokenDto GenerateTokenJWT(UserEntity userEntity)
        {
            IConfigurationSection tokenAppSetting = _configuration.GetSection("Tokens");

            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenAppSetting.GetSection("Key").Value));
            var _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var _header = new JwtHeader(_signingCredentials);

            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(TypeClaims.IdUser,userEntity.Id.ToString()),
                new Claim(TypeClaims.IdRol,userEntity.IdRole.ToString())

            };

            var _payload = new JwtPayload(
                    issuer: tokenAppSetting.GetSection("Issuer").Value,
                    audience: tokenAppSetting.GetSection("Audience").Value,
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(60)
                );

            var _token = new JwtSecurityToken(
                    _header,
                    _payload
                );

            TokenDto token = new TokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(_token),
                Expiration = Utils.ConvertToUnixTimestamp(_token.ValidTo),
            };
            return token;
        }

        #endregion

        public GetUserDto Get(int idUser)
        {
            UserEntity user = _unitOfWork.UserRepository.FirstOrDefault(x => x.Id == idUser)
                ?? throw new BusinessException(GeneralMessages.ItemNoFound);
            GetUserDto getUser = new GetUserDto()
            {
                Id = user.Id,               
                Password = user.Password,
                IdRole = user.IdRole,
            };
            return getUser;
        }

        public List<GetUserDto> GetAll()
        {
            IEnumerable<UserEntity> userQuery = _unitOfWork.UserRepository.GetAll(x => x.RoleEntity);

            List<GetUserDto> usuarios = userQuery.Select(x => new GetUserDto()
            {
                Id = x.Id,
                Password = x.Password,
                IdRole = x.IdRole,
                Role = x.RoleEntity.Description,
            })
            .ToList();
            return usuarios;
        }

        public async Task<bool> Insert(AddUserDto dto)
        {
            if (_unitOfWork.UserRepository.FirstOrDefault(x => x.UserName == dto.UserName) != null)
                throw new BusinessException(GeneralMessages.RegisteredUserName);

            UserEntity user = new UserEntity()
            {               
                Password = Common.Helpers.Utils.PassEncrypt(dto.Password),               
                IdRole = dto.IdRole
            };
            _unitOfWork.UserRepository.Insert(user);

            return await _unitOfWork.Save() > 0;
        }


        public async Task<bool> Delete(int id)
        {
            UserEntity? userEntity = _unitOfWork.UserRepository.FirstOrDefault((user) => user.Id == id);

            if (userEntity == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            
            _unitOfWork.UserRepository.Delete(userEntity);

            return await _unitOfWork.Save() > 0;
        }


        public async Task<bool> UpdatePassword(UserPasswordDto password, int idUser)
        {
            UserEntity userExist = _unitOfWork.UserRepository.FirstOrDefault(x => x.Id == idUser);
            if (userExist == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            string userEnteredPassword = password.Password;
            string hashedPasswordFromDatabase = userExist.Password;

            if (!Utils.VerifyPassword(userEnteredPassword, hashedPasswordFromDatabase))
                throw new BusinessException(GeneralMessages.PasswordIncorrect);

            userExist.Password = Common.Helpers.Utils.PassEncrypt(password.NewPassword);
            _unitOfWork.UserRepository.Update(userExist);

            return await _unitOfWork.Save() > 0;
        }

    }
}
