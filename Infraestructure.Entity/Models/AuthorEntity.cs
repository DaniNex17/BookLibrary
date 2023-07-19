using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("Author", Schema = "Library")]
    public class AuthorEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string? Name { get; set; }
        [MaxLength(200)]
        public string? LastName { get; set; }

        public IEnumerable<BookEntity> BookEntity { get; }
    }
}
