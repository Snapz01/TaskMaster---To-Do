using Microsoft.AspNetCore.Mvc;
using TaskMaster.Data;
using TaskMaster.Models;

namespace TaskMaster.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleService _peopleService;

        public PeopleController(PeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public IActionResult Index()
        {
            var people = _peopleService.FindAll();
            var model = new PeopleViewModel { People = people.ToList() };
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                _peopleService.CreatePerson(model.FirstName, model.LastName);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var person = _peopleService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _peopleService.RemovePersonById(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var person = _peopleService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        public IActionResult Edit(int id)
        {
            var person = _peopleService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            var model = new CreatePersonViewModel { FirstName = person.FirstName, LastName = person.LastName };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, CreatePersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = _peopleService.FindById(id);
                if (person == null)
                {
                    return NotFound();
                }
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
