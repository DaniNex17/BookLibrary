using Common.Resources;
using Library.Domain.Dto;
using Library.Domain.Dto.Author;
using Library.Domain.Services.Interfaces;
using LibraryWeb.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWeb.Controllers
{
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class AuthorController : Controller
    {
        #region Attribute
        private readonly IAuthorServices _authorServices;
        #endregion

        #region Builder
        public AuthorController(IAuthorServices authorServices)
        {
            _authorServices = authorServices;
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
            List<AuthorDto> authors = _authorServices.GetAll();
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = authors
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddAuthorDto authorDto)
        {
            bool isCreated = await _authorServices.Create(authorDto);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = isCreated,
                Message = isCreated ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted,
                Result = isCreated
            };

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(AuthorDto updateAuthorDto)
        {
            bool isUpdated = await _authorServices.Update(updateAuthorDto);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = isUpdated,
                Message = isUpdated ? GeneralMessages.ItemUpdated : GeneralMessages.ItemNoUpdated,
                Result = isUpdated
            };

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _authorServices.Delete(id);
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
