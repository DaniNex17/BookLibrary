using Library.Domain.Dto.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Services.Interfaces
{
    public interface IAuthorServices
    {
        Task<AuthorDto> GetById(int id);
        Task<IEnumerable<AuthorDto>> GetAll();
        Task Create(AuthorDto authorDto);
        Task Update(AuthorDto authorDto);
        Task Delete(int id);
    }
}
