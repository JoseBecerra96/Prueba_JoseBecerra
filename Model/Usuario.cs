using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model
{
    public class Usuario
    {
        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }

        [JsonPropertyName("nombre")]
        [Required(ErrorMessage = "El Nombre es requerido")]
        [MaxLength(50,ErrorMessage = "La longuitud maxima es de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\sáéíóúÁÉÍÓÚ]+$", ErrorMessage = "Solo se permiten letras y espacios.")]
        public string Nombre { get; set; }

        [JsonPropertyName("email")]
        [Required(ErrorMessage = "El Email es requerido")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        [JsonPropertyName("edad")]
        [Required(ErrorMessage = "La Edad es requerida")]
        public byte Edad { get; set; }
    }
}
