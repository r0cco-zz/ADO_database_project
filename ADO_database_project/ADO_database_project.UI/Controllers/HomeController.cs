using ADO_database_project.Data.EmployeeRepository;
using ADO_database_project.Models;
using ADO_database_project.UI.Models;
using System.Web.Mvc;

namespace ADO_database_project.UI.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeRepository repo;

        public HomeController()
        {
            repo = new EmployeeRepository();
        }

        public ActionResult Index()
        {
            var employees = repo.GetAll();
            return View(employees);
        }

        public ActionResult GetID()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetUserByID()
        {
            var emp = new Employee();
            emp.EmployeeId = int.Parse(Request.Form["EmployeeID"]);
            emp = repo.GetById(emp.EmployeeId);

            return View("Result", emp);
        }

        public ActionResult SelectEmployeeByCity()
        {
            EmployeesCitiesVM vmodel = new EmployeesCitiesVM();
            vmodel.listOfCities = vmodel.GetAllCities();


            return View(vmodel);
        }

       
    }
}