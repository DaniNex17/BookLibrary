using Common.Exceptions;
using Common.Resources;
using Infraestructure.Entity.Models;
using Infraestructure.UnitOfWork.Interface;
using Library.Domain.Dto.Author;
using Library.Domain.Dto.Editorial;
using Library.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Services
{
    public class EditorialServices : IEditorialServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditorialServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EditorialDto> GetById(int id)
        {
            EditorialEntity editorial = _unitOfWork.EditorialRepository.FirstOrDefault(x => x.Id == id)
                ?? throw new BusinessException(GeneralMessages.ItemNoFound);
            EditorialDto getEditorial = new EditorialDto()
            {
                Id = editorial.Id,
                Name = editorial.Name,
                Sede = editorial.Sede

            };
            return getEditorial;
        }

        public async Task<IEnumerable<EditorialDto>> GetAll()
        {
            var editorialEntities = _unitOfWork.EditorialRepository.GetAll().ToList();
            var editorialDtos = editorialEntities.Select(editorialEntity => new EditorialDto
            {
                Id = editorialEntity.Id,
                Name = editorialEntity.Name,
                Sede = editorialEntity.Sede
            }).ToList();

            return editorialDtos;
        }

        public async Task Create(EditorialDto editorialDto)
        {
            if (_unitOfWork.EditorialRepository.FirstOrDefault(x => x.Name == editorialDto.Name && x.Sede == editorialDto.Sede) != null)
                throw new BusinessException("No se puede insertar una editorial duplicada");

            EditorialEntity editorialEntity = new EditorialEntity
            {
                Name = editorialDto.Name,
                Sede = editorialDto.Sede
            };

            _unitOfWork.EditorialRepository.Insert(editorialEntity);
            await _unitOfWork.Save();
        }

        public async Task Update(EditorialDto updateEditorialDto)
        {
            EditorialEntity editorialEntity = _unitOfWork.EditorialRepository.FirstOrDefault(x => x.Id == updateEditorialDto.Id);
            if (editorialEntity == null)
                throw new BusinessException("El editor no existe");

            editorialEntity.Name = updateEditorialDto.Name;
            editorialEntity.Sede = updateEditorialDto.Sede;

            _unitOfWork.EditorialRepository.Update(editorialEntity);
            await _unitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            EditorialEntity editorialEntity = _unitOfWork.EditorialRepository.FirstOrDefault(x => x.Id == id);
            if (editorialEntity == null)
                throw new BusinessException("El editor no existe");

            _unitOfWork.EditorialRepository.Delete(editorialEntity);
            await _unitOfWork.Save();
        }    
    }
}
