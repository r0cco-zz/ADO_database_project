using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_database_project.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? ReportsTo { get; set; }
        public string ManagerName { get; set; }
        public string Territory { get; set; }
    }
}
