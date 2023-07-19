using Library.Domain.Dto.Editorial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Services.Interfaces
{
    public interface IEditorialServices
    {
        Task<IEnumerable<EditorialDto>> GetAll();
        Task<EditorialDto> GetById(int id);
        Task Create(EditorialDto editorialDto);
        Task Update(EditorialDto editorialDto);
        Task Delete(int id);
    }
}
