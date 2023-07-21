using Common.Resources;
using Library.Domain.Dto;
using Library.Domain.Dto.Book;
using Library.Domain.Services;
using Library.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWeb.Controllers
{
    public class BookController : Controller
    {
        #region Attribute
        private readonly IBookServices _bookServices;
        #endregion

        #region Builder
        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult Index()
        {
            //IEnumerable<BookDto> books = await _bookServices.GetAll();
            return View();
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    BookDto book = await _bookServices.GetById(id);
        //    return Ok(book);
        //}

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<BookDto> books = _bookServices.GetAll();
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = books
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddBookDto bookDto)
        {
            bool isCreated = await _bookServices.Create(bookDto);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = isCreated,
                Message = isCreated ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted,
                Result = isCreated
            };

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookDto bookDto)
        {
            bool isUpdated = await _bookServices.Update(bookDto);
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
            bool isDeleted = await _bookServices.Delete(id);
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
