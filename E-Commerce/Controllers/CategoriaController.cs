﻿using E_Commerce.Datos;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoriaController(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = _db.Categoria;

            return View(lista);
        }

        //Get
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _db.Categoria.Add(categoria);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(categoria);
        }
    }
}
