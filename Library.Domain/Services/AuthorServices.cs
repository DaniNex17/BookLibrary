using Common.Exceptions;
using Common.Resources;
using Infraestructure.Entity.Models;
using Infraestructure.UnitOfWork.Interface;
using Library.Domain.Dto.Author;
using Library.Domain.Dto.User;
using Library.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Services
{
    public class AuthorServices : IAuthorServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthorDto> GetById(int id)
        {
            AuthorEntity author = _unitOfWork.AuthorRepository.FirstOrDefault(x => x.Id == id)
                ?? throw new BusinessException(GeneralMessages.ItemNoFound);
            AuthorDto getAuthor = new AuthorDto()
            {
                Id = author.Id,
                Name = author.Name,
                LastName = author.LastName
                
            };
            return getAuthor;
        }

        public async Task<IEnumerable<AuthorDto>> GetAll()
        {
            var authorEntities = _unitOfWork.AuthorRepository.GetAll().ToList();
            var authorDtos = authorEntities.Select(authorEntity => new AuthorDto
            {
                Id = authorEntity.Id,
                Name = authorEntity.Name,
                LastName = authorEntity.LastName
            }).ToList();

            return authorDtos;
        }

        public async Task Create(AuthorDto authorDto)
        {
            if (_unitOfWork.AuthorRepository.FirstOrDefault(x => x.Name == authorDto.Name && x.LastName == authorDto.LastName) != null)
                throw new BusinessException("No se puede insertar un autor duplicado");

            AuthorEntity authorEntity = new AuthorEntity
            {
                Name = authorDto.Name,
                LastName = authorDto.LastName
            };

            _unitOfWork.AuthorRepository.Insert(authorEntity);
            await _unitOfWork.Save();
        }

        public async Task Update(AuthorDto updateAuthorDto)
        {
            AuthorEntity authorEntity = _unitOfWork.AuthorRepository.FirstOrDefault(x => x.Id == updateAuthorDto.Id);
            if (authorEntity == null)
                throw new BusinessException("El autor no existe");

            authorEntity.Name = updateAuthorDto.Name;
            authorEntity.LastName = updateAuthorDto.LastName;

            _unitOfWork.AuthorRepository.Update(authorEntity);
            await _unitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            AuthorEntity authorEntity = _unitOfWork.AuthorRepository.FirstOrDefault(x => x.Id == id);
            if (authorEntity == null)
                throw new BusinessException("El autor no existe");

            _unitOfWork.AuthorRepository.Delete(authorEntity);
            await _unitOfWork.Save();
        }
    }
}
