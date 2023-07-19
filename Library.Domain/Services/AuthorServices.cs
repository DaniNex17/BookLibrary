using Common.Exceptions;
using Infraestructure.Entity.Models;
using Infraestructure.UnitOfWork.Interface;
using Library.Domain.Dto.Author;
using Library.Domain.Services.Interfaces;

namespace Library.Domain.Services
{
    public class AuthorServices : IAuthorServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public AuthorServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        private AuthorEntity GetById(int id) => _unitOfWork.AuthorRepository.FirstOrDefault(x => x.Id == id);

        public List<AuthorDto> GetAll()
        {
            IEnumerable<AuthorEntity> authorEntities = _unitOfWork.AuthorRepository.GetAll();

            List<AuthorDto> authorDtos = authorEntities.Select(authorEntity => new AuthorDto
            {
                Id = authorEntity.Id,
                Name = authorEntity.Name,
                LastName = authorEntity.LastName
            }).ToList();

            return authorDtos;
        }

        public async Task<bool> Create(AddAuthorDto authorDto)
        {
            if (_unitOfWork.AuthorRepository.FirstOrDefault(x => x.Name.ToLower() == authorDto.Name.ToLower()
                                                           && x.LastName.ToLower() == authorDto.LastName.ToLower()) != null)
                throw new BusinessException("No se puede insertar un autor duplicado");

            AuthorEntity authorEntity = new AuthorEntity
            {
                Name = authorDto.Name,
                LastName = authorDto.LastName
            };
            _unitOfWork.AuthorRepository.Insert(authorEntity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Update(AuthorDto updateAuthorDto)
        {
            AuthorEntity authorEntity = GetById(updateAuthorDto.Id);
            if (authorEntity == null)
                throw new BusinessException("El autor no existe");

            authorEntity.Name = updateAuthorDto.Name;
            authorEntity.LastName = updateAuthorDto.LastName;
            _unitOfWork.AuthorRepository.Update(authorEntity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            AuthorEntity authorEntity = GetById(id);
            if (authorEntity == null)
                throw new BusinessException("El autor no existe");

            _unitOfWork.AuthorRepository.Delete(authorEntity);

            return await _unitOfWork.Save() > 0;
        }
        #endregion
    }
}
