using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Models
{
    [Table("Author", Schema = "Library")]
    public class AuthorEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }

        public IEnumerable<BookEntity> BookEntity { get; }

        [NotMapped]
        public string FullName { get { return $"{this.Name} {this.LastName}"; } }
    }
}
