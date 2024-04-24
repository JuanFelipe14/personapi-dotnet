using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.ViewModels;

namespace personapi_dotnet.Controllers
{
    public class TelefonoController : Controller
    {
        private readonly PersonaDbContext _personaDbContext;

        public TelefonoController(PersonaDbContext personaDbContext)
        {
            _personaDbContext = personaDbContext;
        }
        // GET: TelefonoController
        public async Task<ActionResult> Index()
        {
            var telefonos = _personaDbContext.Telefonos.Include(t => t.DuenioNavigation);
            return View(await telefonos.ToListAsync());
        }

        // GET: TelefonoController/Details/5
        public ActionResult Details(string id)
        {
            var telefono = _personaDbContext.Telefonos.Find(id);

            if(telefono != null)
            {
                return View(telefono);
            }
            return View();
        }

        // GET: TelefonoController/Create
        public ActionResult Create()
        {
            ViewBag.Duenios = new SelectList(_personaDbContext.Personas, "Cc", "Nombre");
            return View();
        }

        // POST: TelefonoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TelefonoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var telefono = new Telefono()
                {
                    Num = model.Num,
                    Oper = model.Oper,
                    Duenio = model.Duenio
                };
                _personaDbContext.Telefonos.Add(telefono);
                await _personaDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Duenios = new SelectList(_personaDbContext.Personas, "Cc", "Nombre", model.Duenio);
            return View();
        }

        // GET: TelefonoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TelefonoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: TelefonoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TelefonoController/Delete/5
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
