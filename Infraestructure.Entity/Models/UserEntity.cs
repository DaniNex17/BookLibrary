using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Models
{
    [Table("User", Schema = "Security")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(300)]
        public string Password { get; set; }


        [ForeignKey("RoleEntity")]
        public int IdRole { get; set; }
        public RoleEntity RoleEntity { get; set; }
    }
}
