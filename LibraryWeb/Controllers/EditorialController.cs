using Common.Exceptions;
using Common.Resources;
using Library.Domain.Dto;
using Library.Domain.Dto.Editorial;
using Library.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWeb.Controllers
{
    public class EditorialController : Controller
    {
        #region Attribute
        private readonly IEditorialServices _editorialServices;
        #endregion

        #region Builder
        public EditorialController(IEditorialServices editorialServices)
        {
            _editorialServices = editorialServices;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<EditorialDto> editorials = _editorialServices.GetAll();
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = editorials
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddEditorialDto editorialDto)
        {
            bool isCreated = await _editorialServices.Create(editorialDto);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = isCreated,
                Message = isCreated ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted,
                Result = isCreated
            };

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(EditorialDto updateEditorialDto)
        {
            bool isUpdated = await _editorialServices.Update(updateEditorialDto);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = isUpdated,
                Message = isUpdated ? GeneralMessages.ItemUpdated : GeneralMessages.ItemNoUpdated,
                Result = isUpdated
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _editorialServices.Delete(id);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = isDeleted,
                Message = isDeleted ? GeneralMessages.ItemDeleted : GeneralMessages.ItemNoDeleted,
                Result = isDeleted
            };

            return Ok(response);
        } 
        #endregion
    }
}
