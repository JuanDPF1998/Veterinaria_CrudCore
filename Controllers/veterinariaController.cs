using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria_crudcore.Data;
using Veterinaria_crudcore.Models;

namespace Veterinaria_crudcore.Controllers
{
    public class veterinariaController : Controller
    {
        public readonly AppDbContext _context;

        public veterinariaController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            try
            {
                var vete = _context.mascotas.ToList();
                return View(vete);
            }
            catch (DbUpdateException ex)
            {
                return Content($"Se ha prodicudo un error de conexion a la BD {ex.Message}");
            }
            catch (Exception ex)
            {
                return Content("Error al listar: " + ex);
            }
        }
        public IActionResult viewCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Mascotas mascotas)
        {
            try
            {
                var mascota = _context.mascotas.Add(mascotas);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Content($"Error al insertar el registro en la BD: {ex.Message}");
            }
        }
        public IActionResult viewEdit(int id)
        {
            if(id == 0)
            {
                return NoContent();
            }
            var mascota = _context.mascotas.Find(id);
            if(mascota == null)
            {
                return NotFound();
            }
            return View(mascota);
        }
    }
}
