using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.ViewModels;

namespace personapi_dotnet.Controllers
{
    public class EstudioController : Controller
    {
        private readonly PersonaDbContext _personaDbContext;

        public EstudioController(PersonaDbContext personaDbContext)
        {
            _personaDbContext = personaDbContext;
        }
        // GET: EstudioController
        public async Task<ActionResult> Index()
        {
            var estudios = _personaDbContext.Estudios.Include(e => e.IdProfNavigation).Include(e => e.CcPerNavigation);
            return View(await estudios.ToListAsync());
        }

        // GET: EstudioController/Details/5
        public ActionResult Details(int id1, int id2)
        {
            var estudio = _personaDbContext.Estudios.Find(id1,id2);

            if (estudio != null)
            {
                return View(estudio);
            }
            return View();
        }

        // GET: EstudioController/Create
        public ActionResult Create()
        {
            ViewBag.Personas = new SelectList(_personaDbContext.Personas, "Cc", "Nombre");
            ViewBag.Profesiones = new SelectList(_personaDbContext.Profesions, "Id", "Nom");
            return View();
        }

        // POST: EstudioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EstudioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var persona_create = _personaDbContext.Personas.Find(model.CcPer);
                var profesion_create = _personaDbContext.Profesions.Find(model.CcPer);
                var estudio = new Estudio ()
                {
                    IdProf = model.IdProf,
                    CcPer = model.CcPer,
                    Fecha = model.Fecha,
                    Univer = model.Univer,
                    CcPerNavigation = persona_create,
                    IdProfNavigation = profesion_create
                };
                _personaDbContext.Estudios.Add(estudio);
                await _personaDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Personas = new SelectList(_personaDbContext.Personas, "Cc", "Nombre");
            ViewBag.Profesiones = new SelectList(_personaDbContext.Profesions, "Id", "Nom");
            return View();
        }

        // GET: EstudioController/Edit/5
        public ActionResult Edit(int id1,int id2)
        {
            try
            {
                ViewBag.Personas = new SelectList(_personaDbContext.Personas, "Cc", "Nombre");
                ViewBag.Profesiones = new SelectList(_personaDbContext.Profesions, "Id", "Nom");

                var estudio_edit = _personaDbContext.Estudios.Find(id1,id2);
                if (estudio_edit != null)
                {
                    return View(estudio_edit);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: EstudioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Estudio model)
        {
            try
            {
                ViewBag.Personas = new SelectList(_personaDbContext.Personas, "Cc", "Nombre");
                ViewBag.Profesiones = new SelectList(_personaDbContext.Profesions, "Id", "Nom");

                var estudio_edit = _personaDbContext.Estudios.Find(model.IdProf, model.CcPer);
                var persona_edit = _personaDbContext.Personas.Find(model.CcPer);
                var profesion_edit = _personaDbContext.Profesions.Find(model.IdProf); 
                if (estudio_edit != null)
                {
                    _personaDbContext.Estudios.Remove(estudio_edit);
                    model.CcPerNavigation = persona_edit;
                    model.IdProfNavigation = profesion_edit;
                    _personaDbContext.Estudios.Add(model);
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

        // GET: EstudioController/Delete/5
        public ActionResult Delete(int id1, int id2)
        {
            var estudio_delete = _personaDbContext.Estudios.Find(id1,id2);
            if (estudio_delete != null)
            {
                return View(estudio_delete);
            }
            return View();
        }

        // POST: EstudioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Estudio model)
        {
            try
            {
                _personaDbContext.Estudios.Remove(model);
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
