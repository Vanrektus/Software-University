using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace _08.IncreaseMinionAge
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int[] ids = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            SqlConnection connToMinonsDB = new SqlConnection(Configuration.CONNECTION_MINIONSDB_STRING);
            await connToMinonsDB.OpenAsync();

            await using (connToMinonsDB)
            {
                SqlCommand updateMinions = new SqlCommand(Queries.UPDATE_MINIONS, connToMinonsDB);

                foreach (var currId in ids)
                {
                    updateMinions.Parameters.Clear();
                    updateMinions.Parameters.AddWithValue("@Id", currId);
                    await updateMinions.ExecuteNonQueryAsync();
                }

                SqlDataAdapter adapter = new SqlDataAdapter(Queries.GET_MINIONS_INFO, connToMinonsDB);
                DataTable table = new DataTable();

                using (adapter)
                {
                    adapter.Fill(table);
                }

                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"{row[0]} {row[1]}");
                }
            }
        }
    }
}
