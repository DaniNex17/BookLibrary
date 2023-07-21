using Common.Exceptions;
using Library.Domain.Dto;
using Library.Domain.Dto.Author;
using Library.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Common.Constant.Const;

namespace LibraryWeb.Controllers
{
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
            return Ok(authors);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddAuthorDto authorDto)
        {
            try
            {
                bool isCreated = await _authorServices.Create(authorDto);
                return Ok(isCreated);
            }
            catch (BusinessException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(AuthorDto updateAuthorDto)
        {
            bool isUpdated = await _authorServices.Update(updateAuthorDto);
            return Ok(isUpdated);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _authorServices.Delete(id);
            return Ok(isDeleted);
        } 
        #endregion

    }
}
