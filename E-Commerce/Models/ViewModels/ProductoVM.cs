using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Models.ViewModels
{
    public class ProductoVM
    {
        public Producto producto { get; set; }

        public IEnumerable<SelectListItem>? CategoriaLista { get; set; }

        public IEnumerable<SelectListItem>? TipoAplicacionLista { get; set; }
    }
}
