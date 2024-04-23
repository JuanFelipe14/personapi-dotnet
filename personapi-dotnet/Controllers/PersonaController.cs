using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.NewFolder;

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
            return View(await _personaDbContext.Personas.ToListAsync());
        }

        // GET: PersonaController/Details/5
        public ActionResult Details(int id)
        {
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
            try
            {
                var persona = new Persona()
                {
                    Cc = model.Cc,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Genero = model.Genero,
                    Edad = model.Edad
                };
                _personaDbContext.Add(persona);
                await _personaDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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

                    _personaDbContext.Remove(persona_edit);
                    _personaDbContext.Add(model);
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
            return View();
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
