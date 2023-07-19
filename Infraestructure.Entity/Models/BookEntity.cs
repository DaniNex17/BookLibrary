using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Models
{
    [Table("Book", Schema = "Library")]
    public class BookEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Sinopsis { get; set; }


        [Required]
        public int N_Pages { get; set; }

        [MaxLength(int.MaxValue)]
        public string? UrlImage { get; set; }

        [ForeignKey("AutorEntity")]
        public int IdAuthor { get; set; }
        public AuthorEntity AuthorEntity { get; set; }


        [ForeignKey("EditorialEntity")]
        public int IdEditorial { get; set; }
        public EditorialEntity EditorialEntity { get; set; }
    }
}
