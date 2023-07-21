using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Dto.Book
{
    public class AddBookDto
    { 
        public string Title { get; set; }
        public string Sinopsis { get; set; }
        public int N_Pages { get; set; }
        public int IdAuthor { get; set; }
        public int IdEditorial { get; set; }
        public string? UrlImage { get; set; }
    }
}
