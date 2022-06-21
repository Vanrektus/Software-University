using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdoDemoProject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            SqlConnection conn = new SqlConnection(@"Server=.;Database=SoftUni;User Id=sa;Password=SoftUni!2022;TrustServerCertificate=True");
            await conn.OpenAsync();

            using (conn)
            {
                //SqlCommand cmd = new SqlCommand("SELECT TOP 10 * FROM Employees", conn);


                // SQL Injection
                // string name = "' OR 1=1 --";
                 string name = "Gosho";
                // SqlCommand cmd = new SqlCommand("SELECT TOP 1000 * FROM Employees WHERE FirstName = '" + firstName + "'", conn);


                // SQL Injection Protection
                SqlCommand cmd = new SqlCommand("SELECT TOP 10 * FROM Employees WHERE FirstName = @firstName", conn);
                cmd.Parameters.AddWithValue("firstName", name);

                using (cmd)
                {
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    using (reader)
                    {
                        while (await reader.ReadAsync())
                        {
                            string firstName = (string)reader["FirstName"];
                            string lastName = (string)reader["LastName"];
                            decimal salary = (decimal)reader["Salary"];

                            employees.Add(new Employee()
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                Salary = salary
                            });
                        }
                    }
                }
            }

            foreach (var currEmployee in employees)
            {
                Console.WriteLine($"{currEmployee.FirstName} {currEmployee.LastName} - {currEmployee.Salary}");
            }
        }
    }
}
