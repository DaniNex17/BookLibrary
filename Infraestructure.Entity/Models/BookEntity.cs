using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [MaxLength(500)]
        public string? Sinopsis { get; set; }
        [Required]
        [MaxLength(int.MaxValue)]
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
