using E_Commerce.Datos;
using E_Commerce.Models;
using E_Commerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    public class ProductoController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ProductoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Producto> lista = _db.Producto.Include(c => c.Categoria)
                                                      .Include(t => t.TipoAplicacion);
            return View(lista);
        }

        //Get
        public IActionResult Upsert(int? Id)
        {

            //IEnumerable<SelectListItem> categoriaDropDown = _db.Categoria.Select(c => new SelectListItem 
            //{ 
            //    Text = c.NombreCategoria,
            //    Value = c.Id.ToString()

            //});

            //ViewBag.CategoriaDropDown = categoriaDropDown;
            //Producto producto = new Producto();

            ProductoVM productoVM = new ProductoVM()
            {
                producto = new Producto(),
                CategoriaLista = _db.Categoria.Select(c => new SelectListItem
                {
                    Text = c.NombreCategoria,
                    Value = c.Id.ToString()

                }),
                TipoAplicacionLista = _db.TipoAplicacion.Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()

                })
            };

            if (Id == null)
            {
              //Crear el nuevo producto
              return View(productoVM);    
            }
            else
            {
                productoVM.producto = _db.Producto.Find(Id);
                if (productoVM.producto == null)
                {
                    return NotFound();
                }
                return View(productoVM);
            }
        }
    }
}
