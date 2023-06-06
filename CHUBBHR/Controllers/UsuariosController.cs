﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CHUBBHR.Models;

namespace CHUBBHR.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly RegistroContext _context;

        public UsuariosController(RegistroContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var registroContext = _context.Usuarios.Include(u => u.PosicionFkNavigation);
            return View(await registroContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.PosicionFkNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["PosicionFk"] = new SelectList(_context.Posicions, "Id", "Id");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Fecha,PosicionFk")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PosicionFk"] = new SelectList(_context.Posicions, "Id", "Id", usuario.PosicionFk);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["PosicionFk"] = new SelectList(_context.Posicions, "Id", "Id", usuario.PosicionFk);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Fecha,PosicionFk")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PosicionFk"] = new SelectList(_context.Posicions, "Id", "Id", usuario.PosicionFk);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.PosicionFkNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'RegistroContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        // GET: Usuarios/Evaluar/5
        public async Task<IActionResult> Evaluar(int? id, string competencia)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            // Lógica de evaluación aquí

            return View("Evaluar");
        }


        // POST: Usuarios/Evaluar
        [HttpPost]
        public async Task<IActionResult> Evaluar(int id, string seleccion)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            switch (seleccion)
            {
                case "Contribuidor individual":
                    ViewData["Competencias"] = new List<string> { "Resolución de Problemas", "Aprendizaje Continuo", "Iniciativa", "Adaptabilidad", "Orientación a Resultados", "Orientación a Valores" };
                    break;
                case "Líderes":
                    ViewData["Competencias"] = new List<string> { "Visión de Negocio", "Influencia", "Liderazgo Equipo Inclusivo", "Ejecución", "Ownership", "Integridad y Coraje", "Enfoque Estratégico" };
                    break;
                case "Todos los niveles":
                    ViewData["Competencias"] = new List<string> { "Compatibilidad", "Orientación al Cliente", "Trabajo bajo Presión" };
                    break;
                default:
                    return BadRequest();
            }

            ViewData["Titulo"] = "Competencias para " + seleccion;

            return View();
        }


        public IActionResult DesplegarSegundoDeslizador(string opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case "contribuidor-individual":
                    // Código para desplegar el segundo deslizador con las opciones para "contribuidor individual"
                    return PartialView("_SegundoDeslizadorContribuidorIndividual");
                case "lideres":
                    // Código para desplegar el segundo deslizador con las opciones para "líderes"
                    return PartialView("_SegundoDeslizadorLideres");
                case "todos-los-niveles":
                    // Código para desplegar el segundo deslizador con las opciones para "todos los niveles"
                    return PartialView("_SegundoDeslizadorTodosLosNiveles");
                default:
                    return BadRequest();
            }
        }

        // GET: Usuarios/ResolucionProblemas

        public ActionResult Rproblemas()
        {
            return View("resolucionproblemas");
        }

        public IActionResult Competencias()
        {
            // Aquí puedes realizar la lógica necesaria antes de mostrar la vista de competencias

            return View();
        }


        public IActionResult FinalizarEvaluacion()
        {
            // Obtener el valor de la calificación guardado en localStorage
            var calificacion = HttpContext.Session.GetString("calificacion");

            // Asignar el valor de la calificación al ViewBag para que esté disponible en la vista
            ViewBag.Calificacion = calificacion;

            // Redirigir a la vista Usuarios
            return RedirectToAction("Usuarios");
        }

        public IActionResult Calificacion(int? calificacion)
        {
            // Puedes utilizar el valor de la calificación aquí según tus necesidades
            // Por ejemplo, guardarlo en la base de datos, realizar algún cálculo, etc.

            return View();
        }
    }
}
