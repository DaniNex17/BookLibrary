using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Dto.Book
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public string Sinopsis { get; set; }
        public int N_Pages { get; set; }
        public string UrlImage { get; set; }
        public int IdAuthor { get; set; }
        public int IdEditorial { get; set; }
    }
}
