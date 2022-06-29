using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                Console.WriteLine(GetEmployeesFullInformation(dbContext));
            }
        }

        // 03. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
{
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    MiddleName = e.MiddleName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary,
                })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var curr in employees)
            {
                result.AppendLine($"{curr.FirstName} {curr.LastName} {curr.MiddleName} {curr.JobTitle} {curr.Salary:f2}");
            }

            return result.ToString().TrimEnd();
        }

        // 04. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    Salary = e.Salary,
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var curr in employees)
            {
                result.AppendLine($"{curr.FirstName} - {curr.Salary:f2}");
            }

            return result.ToString().TrimEnd();
        }

        // 5. Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DepartmentName = e.Department.Name,
                    Salary = e.Salary,
                })
                .Where(e => e.DepartmentName == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var curr in employees)
            {
                result.AppendLine($"{curr.FirstName} {curr.LastName} from {curr.DepartmentName} - ${curr.Salary:f2}");
            }

            return result.ToString().TrimEnd();
        }

        // 6. Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address();
            newAddress.AddressText = "Vitoshka 15";
            newAddress.TownId = 4;

            var employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");
            employee.Address = newAddress;

            context.SaveChanges();

            var employees = context.Employees
                .Select(e => new
                {
                    AddressId = e.AddressId,
                    AddressText = e.Address.AddressText,
                })
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var curr in employees)
            {
                result.AppendLine($"{curr.AddressText}");
            }

            return result.ToString().TrimEnd();
        }

        // 7. Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(e => e.Manager)
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        ProjectStart = ep.Project.StartDate,
                        ProjectEnd = ep.Project.EndDate,
                    })
                })
                .Take(10)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var currEmp in employees)
            {
                result.AppendLine($"{currEmp.FirstName} {currEmp.LastName} - Manager: {currEmp.ManagerFirstName} {currEmp.ManagerLastName}");

                foreach (var currProj in currEmp.Projects)
                {
                    result.AppendLine($"--{currProj.ProjectName} - {currProj.ProjectStart.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {(currProj.ProjectEnd.HasValue ? currProj.ProjectEnd.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished")}");
                }
            }

            return result.ToString().TrimEnd();
        }

        // 8. Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Include(a => a.Town)
                .Include(a => a.Employees)
                .OrderByDescending(x => x.Employees.Count())
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var curr in addresses)
            {
                result.AppendLine($"{curr.AddressText}, {curr.Town.Name} - {curr.Employees.Count()} employees");
            }

            return result.ToString().TrimEnd();
        }

        // 9. Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Projects = e.EmployeesProjects.Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                    })
                    .OrderBy(ep => ep.ProjectName)
                    .ToList()
                })
                .FirstOrDefault();

            StringBuilder result = new StringBuilder();

            result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var curr in employee.Projects)
            {
                result.AppendLine($"{curr.ProjectName}");
            }

            return result.ToString().TrimEnd();
        }

        // 10. Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Include(d => d.Manager)
                .Include(d => d.Employees)
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var currDep in departments)
            {
                result.AppendLine($"{currDep.Name} - {currDep.Manager.FirstName} {currDep.Manager.LastName}");

                foreach (var currEmp in currDep.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    result.AppendLine($"{currEmp.FirstName} {currEmp.LastName} - {currEmp.JobTitle}");
                }
            }

            return result.ToString().TrimEnd();
        }

        // 11. Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    ProjectName = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate,
                })
                .OrderBy(p => p.ProjectName)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var curr in projects)
            {
                result.AppendLine($"{curr.ProjectName}");
                result.AppendLine($"{curr.Description}");
                result.AppendLine($"{curr.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }

            return result.ToString().TrimEnd();
        }

        // 12. Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(e => e.Department)
                .Where(e => e.Department.Name == "Engineering" || 
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Salary = e.Salary * 1.12M,
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            StringBuilder result = new StringBuilder();

            foreach (var curr in employees)
            {
                result.AppendLine($"{curr.FirstName} {curr.LastName} (${curr.Salary:f2})");
            }

            return result.ToString().TrimEnd();
        }

        // 13. Find Employees by First Name Starting with "Sa"
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.ToUpper().StartsWith("SA"))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary,
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            StringBuilder result = new StringBuilder();

            foreach (var curr in employees)
            {
                result.AppendLine($"{curr.FirstName} {curr.LastName} - {curr.JobTitle} - (${curr.Salary:f2})");
            }

            return result.ToString().TrimEnd();
        }

        // 14. Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            var relations = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();
            context.RemoveRange(relations);
            context.SaveChanges();

            var project = context.Projects.Find(2);
            context.RemoveRange(project);
            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var curr in projects)
            {
                result.AppendLine(curr.Name);
            }

            return result.ToString().TrimEnd();
        }

        // 15. Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Include(a => a.Town)
                .Where(a => a.Town.Name == "Seattle")
                .ToList();

            var employees = context.Employees
                .Include(e => e.Address)
                .Where(e => addresses.Contains(e.Address))
                .ToList();

            foreach (var curr in employees)
            {
                curr.AddressId = null;
            }

            int count = addresses.Count();
            context.RemoveRange(addresses);
            context.SaveChanges();

            var town = context.Towns.FirstOrDefault(x => x.Name == "Seattle");
            context.Remove(town);
            context.SaveChanges();

            return $"{count} addresses in Seattle were deleted";
        }
    }
}
