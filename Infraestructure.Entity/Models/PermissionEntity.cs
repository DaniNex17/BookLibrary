using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Models
{
    [Table("Permission", Schema = "Security")]
    public class PermissionEntity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        [ForeignKey("PermissionTypeEntity")]
        public int IdPermissionTypeEntity { get; set; }

        public PermissionTypeEntity PermissionTypeEntity { get; set; }

        public IEnumerable<RolePermissionEntity> RolePermissionEntities { get; set; }


    }
}
