using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria_crudcore.Data;

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
    }
}
