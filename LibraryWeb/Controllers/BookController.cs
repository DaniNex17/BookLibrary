using Library.Domain.Dto.Book;
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
        public async Task<IActionResult> Index()
        {
            IEnumerable<BookDto> books = await _bookServices.GetAll();
            return View(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            BookDto book = await _bookServices.GetById(id);
            return Ok(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<BookDto> books = await _bookServices.GetAll();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddBookDto bookDto)
        {
            await _bookServices.Create(bookDto);
            return Ok(true);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookDto bookDto)
        {
            await _bookServices.Update(bookDto);
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookServices.Delete(id);
            return Ok(true);
        } 
        #endregion
    }
}
