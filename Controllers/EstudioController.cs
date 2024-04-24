using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;

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
        public ActionResult Index()
        {
            return View();
        }

        // GET: EstudioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EstudioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstudioController/Create
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

        // GET: EstudioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstudioController/Edit/5
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

        // GET: EstudioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstudioController/Delete/5
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
