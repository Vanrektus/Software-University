using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace _06.RemoveVillain
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
                SqlCommand getVillainName = new SqlCommand(Queries.GET_VILLAIN_NAME, connToMinonsDB);
                getVillainName.Parameters.AddWithValue("@villainId", villainId);
                SqlDataReader reader = await getVillainName.ExecuteReaderAsync();

                if (!reader.HasRows)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                await reader.ReadAsync();
                string villainName = reader[0].ToString();
                await reader.CloseAsync();

                SqlCommand getMinionsCount = new SqlCommand(Queries.GET_MINIONS_COUNT, connToMinonsDB);
                getMinionsCount.Parameters.AddWithValue("@villainId", villainId);
                int minionsCount = (int)await getMinionsCount.ExecuteScalarAsync();

                SqlCommand removeVillainToMinion = new SqlCommand(Queries.DELETE_FROM_MINIONSVILLAINS, connToMinonsDB);
                removeVillainToMinion.Parameters.AddWithValue("@villainId", villainId);
                await removeVillainToMinion.ExecuteNonQueryAsync();

                SqlCommand removeVillain = new SqlCommand(Queries.DELETE_FROM_VILLAINS, connToMinonsDB);
                removeVillain.Parameters.AddWithValue("@villainId", villainId);

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{minionsCount} minions were released.");
            }
        }
    }
}
