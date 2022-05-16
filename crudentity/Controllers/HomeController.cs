using crudentity.Datos;
using crudentity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace crudentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _contexto;
        public HomeController(ApplicationDBContext contexto)
        {
            _contexto = contexto;
        }
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Usuario.ToListAsync());
        }
        [HttpGet]
        public  IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuario.Add(usuario);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id== null)
            {
                return NotFound();
            }
            var usuario = _contexto.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return View(usuario);

            }
        }
        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _contexto.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return View(usuario);

            }
        }
        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarUsuario(int? id)
        {
            var usuario = await _contexto.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return View();
            }

            _contexto.Usuario.Remove(usuario);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _contexto.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return View(usuario);

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuario.Update(usuario);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}