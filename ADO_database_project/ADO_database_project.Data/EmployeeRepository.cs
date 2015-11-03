using ADO_database_project.Data.Config;
using ADO_database_project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ADO_database_project.Data.EmployeeRepository
{
    public class EmployeeRepository
    {
        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select e1.EmployeeID, e1.FirstName, e1.LastName, " +
                                    "e1.Title, e1.BirthDate, e1.City, e2.FirstName AS ManagerFirstName, " +
                                    "e2.LastName AS ManagerLastName, e1.ReportsTo " +
                                    "FROM Employees e1 " +
                                    "LEFT JOIN Employees e2 ON e1.ReportsTo = e2.EmployeeID";

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        employees.Add(PopulateFromDataReader(dr));
                    }
                }
            }

            return employees;
        }

        public Employee GetByIdStoredProcedure(int employeeId)
        {
            Employee employee = new Employee();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "EmployeesGetByID";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        employee = PopulateFromDataReader(dr);
                    }
                }
            }

            return employee;
        }

        public Employee GetById(int employeeId)
        {
            Employee employee = new Employee();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "select e1.EmployeeID, e1.FirstName, e1.LastName, " +
                                    "e1.Title, e1.BirthDate, e2.FirstName AS ManagerFirstName, " +
                                    "e2.LastName AS ManagerLastName, e1.ReportsTo " +
                                    "FROM Employees e1 " +
                                    "LEFT JOIN Employees e2 ON e1.ReportsTo = e2.EmployeeID " +
                                    "WHERE e1.EmployeeID = @EmployeeID";

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        employee = PopulateFromDataReader(dr);
                    }
                }
            }

            return employee;
        }

        private Employee PopulateFromDataReader(SqlDataReader dr)
        {
            Employee employee = new Employee();

            employee.EmployeeId = (int)dr["EmployeeID"];
            employee.LastName = dr["LastName"].ToString();
            employee.FirstName = dr["FirstName"].ToString();
            employee.Title = dr["Title"].ToString();
            employee.City = dr["City"].ToString();

            if (dr["BirthDate"] != DBNull.Value)
                employee.BirthDate = (DateTime)dr["BirthDate"];

            if (dr["ReportsTo"] != DBNull.Value)
            {
                employee.ReportsTo = (int)dr["ReportsTo"];
                employee.ManagerName = string.Format("{0} {1}",
                    dr["ManagerFirstName"].ToString(),
                    dr["ManagerLastName"].ToString());
            }

            return employee;
        }

        public Employee EmployeeRegion(int employeeId)
        {
            Employee employee = new Employee();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "select e.EmployeeID, e.FirstName, e.City, e.LastName, t.TerritoryDescription" +
                    "from EmployeeTerritories et" +
                    "inner join Employees e" +
                    "on e.EmployeeID = et.EmployeeID" +
                    "inner join Territories t" +
                    "on et.TerritoryID = t.TerritoryID";

                cmd.Connection = cn;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        employee.EmployeeId = (int)dr["EmployeeID"];
                        employee.LastName = dr["LastName"].ToString();
                        employee.FirstName = dr["FirstName"].ToString();
                        //employee.Territory = dr["TerritoryDescription"].ToString();
                    }
                }
            }

            return employee;
        }

       
    }
}