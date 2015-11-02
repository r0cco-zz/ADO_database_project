using ADO_database_project.Data.EmployeeRepository;
using ADO_database_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO_database_project.UI.Models
{
    public class EmployeesCitiesVM
    {
        public Employee employee { get; set; }
        public List<string> listOfCities { get; set; }

        public List<string> GetAllCities()
        {
            var listOfCities = new List<string>();

            var repo = new EmployeeRepository();

            var employees = repo.GetAll();

            foreach (var emp in employees)
            {
                listOfCities.Add(emp.City);
            }

            return listOfCities;

        }

    }
}