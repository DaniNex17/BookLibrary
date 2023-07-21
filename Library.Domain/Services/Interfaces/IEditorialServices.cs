using Library.Domain.Dto.Author;
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
        List<EditorialDto> GetAll();
        Task<bool> Create(AddEditorialDto editorialDto);
        Task<bool> Update(EditorialDto updateEditorialDto);
        Task<bool> Delete(int id);
    }
}
