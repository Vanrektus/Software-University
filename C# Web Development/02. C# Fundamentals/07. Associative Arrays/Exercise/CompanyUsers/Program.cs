using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> companyUsers = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "End")
                {
                    break;
                }

                if (companyUsers.ContainsKey(input[0]) && !companyUsers[input[0]].Contains(input[1]))
                {
                    companyUsers[input[0]].Add(input[1]);
                }
                else if (!companyUsers.ContainsKey(input[0]))
                {
                    companyUsers.Add(input[0], new List<string>() { input[1] });
                }
            }

            foreach (var company in companyUsers)
            {
                Console.WriteLine(company.Key);

                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
