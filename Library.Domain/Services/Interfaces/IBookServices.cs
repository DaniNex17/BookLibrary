﻿using Library.Domain.Dto.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Services.Interfaces
{
    public interface IBookServices
    {
        Task<BookDto> GetById(int id);
        Task<IEnumerable<BookDto>> GetAll();
        Task Create(BookDto bookDto);
        Task Update(BookDto bookDto);
        Task Delete(int id);
    }
}