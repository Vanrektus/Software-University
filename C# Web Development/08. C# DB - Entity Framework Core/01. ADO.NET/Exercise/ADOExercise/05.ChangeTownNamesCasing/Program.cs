using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace _05.ChangeTownNamesCasing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string countryName = Console.ReadLine();

            SqlConnection connToMinonsDB = new SqlConnection(Configuration.CONNECTION_MINIONSDB_STRING);
            await connToMinonsDB.OpenAsync();

            await using (connToMinonsDB)
            {
                SqlCommand getTowns = new SqlCommand(Queries.GET_TOWNS, connToMinonsDB);
                getTowns.Parameters.AddWithValue("@countryName", countryName);
                SqlDataReader reader = await getTowns.ExecuteReaderAsync();

                if (!reader.HasRows)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                SqlCommand updateTowns = new SqlCommand(Queries.UPDATE_TOWNS, connToMinonsDB);
                updateTowns.Parameters.AddWithValue("@countryName", countryName);
                await updateTowns.ExecuteNonQueryAsync();

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(Queries.GET_TOWNS, connToMinonsDB);
                adapter.SelectCommand.Parameters.AddWithValue("@countryName", countryName);

                using (adapter)
                {
                    adapter.Fill(table);
                }

                int affectedTownsCount = table.Rows.Count;

                await reader.CloseAsync();
                Console.WriteLine($"{affectedTownsCount} town names were affected.");

                List<string> towns = new List<string>();

                foreach (DataRow currRow in table.Rows)
                {
                    towns.Add(currRow[0].ToString());
                }

                Console.WriteLine($"[{String.Join(", ", towns)}]");
            }
        }
    }
}
