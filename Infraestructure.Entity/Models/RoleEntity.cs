using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("Role", Schema = "Security")]
    public class RoleEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }

        public IEnumerable<RolePermissionEntity> RolePermissionEntities { get; set; }
        public IEnumerable<UserEntity> UsersEntities { get; set; }
    }
}
