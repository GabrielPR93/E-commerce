using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Nombre de Categoria es Obligatorio")]
        public string NombreCategoria { get; set; }

        [Required(ErrorMessage ="Orden obligatorio")]
        [Range(1,int.MaxValue, ErrorMessage ="Valor obligatorio mayor de 0")]
        public int MostrarOrden { get; set; }
    }
}
