using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.NewFolder;
using personapi_dotnet.Models.ViewModels;

namespace personapi_dotnet.Controllers
{
    public class PersonaController : Controller
    {
        private readonly PersonaDbContext _personaDbContext;

        public PersonaController(PersonaDbContext personaDbContext)
        {
            _personaDbContext = personaDbContext;
        }
        // GET: PersonaController
        public async Task<ActionResult> Index()
        {
            var personas = _personaDbContext.Personas;
            return View(await personas.ToListAsync());
        }

        // GET: PersonaController/Details/5
        public ActionResult Details(int id)
        {
            var persona = _personaDbContext.Personas.Find(id);

            if (persona != null)
            {
                return View(persona);
            }
            return View();
        }

        // GET: PersonaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PersonaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var persona = new Persona()
                {
                    Cc = model.Cc,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Genero = model.Genero,
                    Edad = model.Edad
                };
                _personaDbContext.Personas.Add(persona);
                await _personaDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: PersonaController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var persona_edit = _personaDbContext.Personas.Find(id);
                if (persona_edit != null)
                {
                    return View(persona_edit);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Persona model)
        {
            try
            {
                var persona_edit = _personaDbContext.Personas.Find(model.Cc);
                if (persona_edit != null)
                {
                    _personaDbContext.Personas.Remove(persona_edit);
                    _personaDbContext.Personas.Add(model);
                    //_personaDbContext.Add(persona_edit);
                    await _personaDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Delete/5
        public ActionResult Delete(int id)
        {
            var persona_delete = _personaDbContext.Personas.Find(id);
            if (persona_delete != null)
            {
                return View(persona_delete);
            }
            return View();
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Persona model)
        {
            try
            {
                _personaDbContext.Personas.Remove(model);
                await _personaDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }
    }
}
