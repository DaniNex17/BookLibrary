using Library.Domain.Dto.Book;

namespace Library.Domain.Services.Interfaces
{
    public interface IBookServices
    {
        List<BookDto> GetAll();
        Task<bool> Create(AddBookDto bookDto);
        Task<bool> Update(UpdateBookDto bookDto);
        Task<bool> Delete(int id);
    }
}
