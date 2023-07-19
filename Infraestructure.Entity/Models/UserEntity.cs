using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("User", Schema = "Security")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        [MaxLength(20)]
        public string? UserName { get; set; }

        [MaxLength(int.MaxValue)]
        public string? Password { get; set; }


        [ForeignKey("RoleEntity")]
        public int IdRole { get; set; }
        public RoleEntity RoleEntity { get; set; }
    }
}
