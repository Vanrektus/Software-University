using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EFIntroDemo.Data.Models
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                var employees = await dbContext.Employees
                    .Where(e => e.Department.Name == "Marketing")
                    .Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        Department = e.Department.Name
                    })
                    .ToListAsync();

                foreach (var currEmployee in employees)
                {
                    Console.WriteLine($"{currEmployee.Name} - {currEmployee.Department}");
                }

                // Select and see the string query
                var employeesQueryString = dbContext.Employees
                    .Where(e => e.Department.Name == "Marketing")
                    .ToQueryString();

                Console.WriteLine($"{Environment.NewLine}" +
                    $"String Query:" +
                    $"{Environment.NewLine}" +
                    $"{employeesQueryString}");
            }
        }
    }
}
