using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.Domain.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El UserName es requerido")]
        [MaxLength(200)]
        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "La contraseña es requerida")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}
