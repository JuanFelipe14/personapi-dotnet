using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;

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
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProfesionController/Details/5
        public ActionResult Details(int id)
        {
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
        public ActionResult Create(IFormCollection collection)
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

        // GET: ProfesionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfesionController/Edit/5
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

        // GET: ProfesionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfesionController/Delete/5
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
