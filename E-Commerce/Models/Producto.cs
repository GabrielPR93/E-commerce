using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Producto
    {

        [Key]
        public int Id { get; set; }    

        [Required(ErrorMessage = "Nombre del producto necesario")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "Descripcion corta necesaria")]
        public int DescripcionCorta { get; set; }

        [Required(ErrorMessage = "Descripcion del producto necesaria")]
        public int DescripcionProducto { get; set; }

        [Required(ErrorMessage = "Precio necesario")]
        [Range(1,int.MaxValue,ErrorMessage = "El precio debe ser mayor de 0")]
        public double Precio { get; set; }

        public string ImagenUrl { get; set; }

        //Foreign Key

        public int CategoriaId { get; set; }
        public int TipoAplicacionId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        [ForeignKey("TipoAplicacionId")]
        public virtual TipoAplicacion TipoAplicacion { get; set; }
    }
}
