using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Dto.Author
{
    public class AddAuthorDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage ="El nombre es obligatorio.")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Display(Name="Apellido")]
        [Required(ErrorMessage = "El Apellido es obligatorio.")]
        [MaxLength(200)]
        public string LastName { get; set; }
    }
}
