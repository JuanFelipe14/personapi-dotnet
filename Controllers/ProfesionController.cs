using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.ViewModels;

namespace personapi_dotnet.Controllers
{
    public class ProfesionController : Controller
    {
        private readonly PersonaDbContext _personaDbContext;

        public ProfesionController(PersonaDbContext personaDbContext)
        {
            _personaDbContext = personaDbContext;
        }
        // GET: ProfesionController
        public async Task<ActionResult> Index()
        {
            var profesiones = _personaDbContext.Profesions;
            return View(await profesiones.ToListAsync()); ;
        }

        // GET: ProfesionController/Details/5
        public ActionResult Details(int id)
        {
            var profesion = _personaDbContext.Profesions.Find(id);

            if (profesion != null)
            {
                return View(profesion);
            }
            return View();
        }

        // GET: ProfesionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfesionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProfesionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var profesion = new Profesion()
                {
                    Id = model.Id,
                    Nom = model.Nom,
                    Des = model.Des
                    
                };
                _personaDbContext.Profesions.Add(profesion);
                await _personaDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: ProfesionController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var profesion_edit = _personaDbContext.Profesions.Find(id);
                if (profesion_edit != null)
                {
                    return View(profesion_edit);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: ProfesionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Profesion model)
        {
            try
            {
                var profesion_edit = _personaDbContext.Profesions.Find(model.Id);
                if (profesion_edit != null)
                {
                    _personaDbContext.Profesions.Remove(profesion_edit);
                    _personaDbContext.Profesions.Add(model);
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

        // GET: ProfesionController/Delete/5
        public ActionResult Delete(int id)
        {
            var profesion_delete = _personaDbContext.Profesions.Find(id);
            if (profesion_delete != null)
            {
                return View(profesion_delete);
            }
            return View();
        }

        // POST: ProfesionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Profesion model)
        {
            try
            {
                _personaDbContext.Profesions.Remove(model);
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
