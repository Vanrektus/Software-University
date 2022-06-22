using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace _04.AddMinion
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split(' ');
            string[] villainInfo = Console.ReadLine().Split(' ');

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string townName = minionInfo[3];
            string villainName = villainInfo[1];

            SqlConnection connToMinonsDB = new SqlConnection(Configuration.CONNECTION_MINIONSDB_STRING);
            await connToMinonsDB.OpenAsync();

            await using (connToMinonsDB)
            {
                SqlCommand getVillainId = new SqlCommand(Queries.GET_VILLAIN_ID, connToMinonsDB);
                SqlDataReader villainReader = await getVillainId.ExecuteReaderAsync();

                SqlCommand getTownId = new SqlCommand(Queries.GET_TOWN_ID, connToMinonsDB);
                SqlDataReader townReader = await getTownId.ExecuteReaderAsync();

                if (!townReader.HasRows)
                {
                    SqlCommand insertIntoTown = new SqlCommand(Queries.INSERT_INTO_TOWNS, connToMinonsDB);
                    insertIntoTown.Parameters.AddWithValue("@townName", townName);
                    await insertIntoTown.ExecuteNonQueryAsync();
                    Console.WriteLine($"Town {townName} was added to the database.");
                }

                await townReader.CloseAsync();

                if (!villainReader.HasRows)
                {
                    SqlCommand insertIntoVillains = new SqlCommand(Queries.INSERT_INTO_VILLAINS, connToMinonsDB);
                    insertIntoVillains.Parameters.AddWithValue("@villainName", villainName);
                    await insertIntoVillains.ExecuteNonQueryAsync();
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                await villainReader.CloseAsync();

                int townId = (int)await getTownId.ExecuteScalarAsync();

                SqlCommand insertIntoMinions = new SqlCommand(Queries.INSERT_INTO_MINIONS, connToMinonsDB);
                insertIntoMinions.Parameters.AddWithValue("@minionName", minionName);
                insertIntoMinions.Parameters.AddWithValue("@age", minionAge);
                insertIntoMinions.Parameters.AddWithValue("@townId", townId);
                await insertIntoMinions.ExecuteNonQueryAsync();

                int villainId = (int)await getTownId.ExecuteScalarAsync();

                SqlCommand insertIntoMinionsVillains = new SqlCommand(Queries.INSERT_INTO_MINIONSVILLAINS, connToMinonsDB);
                insertIntoMinionsVillains.Parameters.AddWithValue("@villainId", villainId);

                SqlCommand getMinionId = new SqlCommand(Queries.GET_MINION_ID, connToMinonsDB);
                getMinionId.Parameters.AddWithValue("@minionName", minionName);
                int minionId = (int)await getMinionId.ExecuteScalarAsync();

                insertIntoMinionsVillains.Parameters.AddWithValue("@minionId", minionId);
                await insertIntoMinionsVillains.ExecuteNonQueryAsync();

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }
    }
}
