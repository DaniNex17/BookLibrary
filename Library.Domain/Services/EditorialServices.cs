using Common.Exceptions;
using Infraestructure.Entity.Models;
using Infraestructure.UnitOfWork.Interface;
using Library.Domain.Dto.Editorial;
using Library.Domain.Services.Interfaces;

namespace Library.Domain.Services
{
    public class EditorialServices : IEditorialServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public EditorialServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        private EditorialEntity GetById(int id) => _unitOfWork.EditorialRepository.FirstOrDefault(x => x.Id == id);

        public List<EditorialDto> GetAll()
        {
            IEnumerable<EditorialEntity> editorialEntities = _unitOfWork.EditorialRepository.GetAll();

            List<EditorialDto> editorialDtos = editorialEntities.Select(editorialEntity => new EditorialDto
            {
                Id = editorialEntity.Id,
                Name = editorialEntity.Name,
                Sede = editorialEntity.Sede,
            }).ToList();

            return editorialDtos;
        }

        public async Task<bool> Create(AddEditorialDto editorialDto)
        {
            if (_unitOfWork.EditorialRepository.FirstOrDefault(x => x.Name.ToLower() == editorialDto.Name.ToLower()
                                                                && x.Sede.ToLower() == editorialDto.Sede.ToLower()) != null)
                throw new BusinessException("No se puede insertar una editorial duplicada");

            EditorialEntity editorialEntity = new EditorialEntity
            {
                Name = editorialDto.Name,
                Sede = editorialDto.Sede
            };

            _unitOfWork.EditorialRepository.Insert(editorialEntity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Update(EditorialDto updateEditorialDto)
        {
            EditorialEntity editorialEntity = GetById(updateEditorialDto.Id);
            if (editorialEntity == null)
                throw new BusinessException("El editor no existe");

            editorialEntity.Name = updateEditorialDto.Name;
            editorialEntity.Sede = updateEditorialDto.Sede;
            _unitOfWork.EditorialRepository.Update(editorialEntity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            EditorialEntity editorialEntity = GetById(id);
            if (editorialEntity == null)
                throw new BusinessException("El editor no existe");

            _unitOfWork.EditorialRepository.Delete(editorialEntity);

            return await _unitOfWork.Save() > 0;
        }
        #endregion
    }
}
