using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace _03.MinionNames
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlConnection connToMinonsDB = new SqlConnection(Configuration.CONNECTION_MINIONSDB_STRING);
            await connToMinonsDB.OpenAsync();

            await using (connToMinonsDB)
            {
                SqlCommand getVillains = new SqlCommand(Queries.GET_VILLAINS_NAMES, connToMinonsDB);
                getVillains.Parameters.AddWithValue("@VillainId", villainId);
                string villainName = (string)await getVillains.ExecuteScalarAsync();

                if (string.IsNullOrEmpty(villainName))
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                    return;
                }

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(Queries.GET_MINIONS_INFO, connToMinonsDB);
                adapter.SelectCommand.Parameters.AddWithValue("@VillainId", villainId);

                using (adapter)
                {
                    adapter.Fill(table);
                }

                Console.WriteLine($"Villain: {villainName}");

                if (table.Rows.Count < 1)
                {
                    Console.WriteLine("(no minions)");
                }

                foreach (DataRow currRow in table.Rows)
                {
                    Console.WriteLine($"{currRow[0]}. {currRow[1]} {currRow[2]}");
                }
            }
        }
    }
}
