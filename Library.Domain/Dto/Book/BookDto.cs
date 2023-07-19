using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Dto.Book
{
    public class BookDto: AddBookDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string EditorialName { get; set; }
    }
}
