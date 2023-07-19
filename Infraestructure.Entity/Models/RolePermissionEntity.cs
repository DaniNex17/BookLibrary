using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Models
{
    [Table("RolesPermissions", Schema = "Security")]
    public class RolePermissionEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RoleEntity")]
        public int IdRol { get; set; }

        public RoleEntity RoleEntity { get; set; }

        [ForeignKey("PermissionEntity")]
        public int IdPermission { get; set; }

        public PermissionEntity PermissionEntity { get; set; }
    }
}
