using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADO_database_project.Data.EmployeeRepository;
using ADO_database_project.Models;

namespace ADO_database_project.UI.Controllers
{
    public class HomeController : Controller
    {
        EmployeeRepository repo;

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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}