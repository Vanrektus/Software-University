using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace _02.VillainNames
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SqlConnection connToMinonsDB = new SqlConnection(Configuration.CONNECTION_MINIONSDB_STRING);
            await connToMinonsDB.OpenAsync();

            await using (connToMinonsDB)
            {
                SqlCommand getVillains = new SqlCommand(Queries.GET_VILLAINS_NAMES, connToMinonsDB);
                SqlDataReader reader = await getVillains.ExecuteReaderAsync();

                await using (reader)
                {
                    while (await reader.ReadAsync())
                    {
                        string villainName = reader.GetString(0);
                        int minionsCount = reader.GetInt32(1);

                        Console.WriteLine($"{villainName} - {minionsCount}");
                    }
                }
            }
        }
    }
}
