using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("Editorial", Schema = "Library")]
    public class EditorialEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Sede { get; set; }

        public IEnumerable<BookEntity> BookEntity { get; }
    }
}
