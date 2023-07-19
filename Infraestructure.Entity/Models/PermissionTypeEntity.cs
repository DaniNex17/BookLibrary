using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Models
{
    [Table("PermissionType", Schema = "Security")]
    public class PermissionTypeEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public IEnumerable<PermissionEntity> PermissionEntity { get; }
    }
}
