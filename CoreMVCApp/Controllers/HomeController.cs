using CoreMVCApp.Data;
using CoreMVCApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public HomeController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        ViewBag.PersonCount = _dbContext.People.Count();
        return View();
    }

    public IActionResult Person(int id)
    {
        //id != 0 then its Edit mode | Find the Person and move the values to View
        //Person tempPerson = new Person();
        Person tempPerson = _dbContext.People.Find(id);

        if (tempPerson == null)
        {
            tempPerson = new Person();
        }

        List<SelectListItem> States = new()
        {
            new SelectListItem { Value = "1", Text = "Kerala" },
            new SelectListItem { Value = "2", Text = "Tamilnadu" },
            new SelectListItem { Value = "3", Text = "Karnadaka" },
            new SelectListItem { Value = "4", Text = "Gujarath" }
        };
        ViewBag.States = States;

        return View(tempPerson);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult PersonSave(Person person)
    {
        if (ModelState.IsValid)
        {
            if (person.ID == 0)
            {
                _dbContext.People.Add(person);
            }
            else
            {
                _dbContext.People.Update(person);
            }

            _dbContext.SaveChanges();
        }

        return RedirectToAction("PersonList");
    }

    public IActionResult PersonList()
    {
        List<Person> persons = _dbContext.People.ToList();
        return View(persons);
    }

    public IActionResult PersonDelete(int id)
    {
        Person tempPerson = _dbContext.People.Find(id);

        if (tempPerson != null)
        {
            _dbContext.People.Remove(tempPerson);
            _dbContext.SaveChanges();
        }

        return RedirectToAction("PersonList");
    }
}
