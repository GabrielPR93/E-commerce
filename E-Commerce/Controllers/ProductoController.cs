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
        private readonly IWebHostEnvironment _webHostEnvironments;

        public ProductoController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironments = webHostEnvironment;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductoVM productoVM) {

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironments.WebRootPath;

                if (productoVM.producto.Id == 0)
                {
                    //Se crea
                    string upload = webRootPath + WC.ImagenRuta;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using (var filesStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filesStream);
                    }

                    productoVM.producto.ImagenUrl = fileName + extension;
                    _db.Producto.Add(productoVM.producto);
                }
                else
                {
                    //Actualizar
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productoVM);


          

        }
        
    }
}
