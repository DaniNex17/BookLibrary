using Library.Domain.Dto.Author;

namespace Library.Domain.Services.Interfaces
{
    public interface IAuthorServices
    {
        List<AuthorDto> GetAll();
        Task<bool> Create(AddAuthorDto authorDto);
        Task<bool> Update(AuthorDto updateAuthorDto);
        Task<bool> Delete(int id);
    }
}
