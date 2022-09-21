using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class TipoAplicacion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre Obligatorio")]
        public string Nombre { get; set; }
    }
}
