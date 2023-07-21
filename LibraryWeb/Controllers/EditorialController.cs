using Common.Exceptions;
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
            return Ok(editorials);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddEditorialDto editorialDto)
        {
            try
            {
                bool isCreated = await _editorialServices.Create(editorialDto);
                return Ok(isCreated);
            }
            catch (BusinessException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(EditorialDto updateEditorialDto)
        {
            bool isUpdated = await _editorialServices.Update(updateEditorialDto);
            return Ok(isUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _editorialServices.Delete(id);
            return Ok(isDeleted);
        } 
        #endregion
    }
}
