using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace _01.InitialSetup
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SqlConnection connToMaster = new SqlConnection(Configuration.CONNECTION_MASTER_STRING);
            await connToMaster.OpenAsync();
            Console.WriteLine("Connected to master");

            await using (connToMaster)
            {
                await CreateDatabase(connToMaster);
            }

            SqlConnection connToMinonsDB = new SqlConnection(Configuration.CONNECTION_MINIONSDB_STRING);
            await connToMinonsDB.OpenAsync();
            Console.WriteLine("Connected to MinionsDB");

            await using (connToMinonsDB)
            {
                await CreateTables(connToMinonsDB);
                await InsertIntoTables(connToMinonsDB);
            }
        }
                

        private static async Task CreateDatabase(SqlConnection connToMaster)
        {
            SqlCommand crDbCmd = new SqlCommand(Queries.CREATE_DB_QUERY, connToMaster);
            await crDbCmd.ExecuteNonQueryAsync();
            Console.WriteLine("Database Created!");
        }

        private static async Task CreateTables(SqlConnection connToMinonsDB)
        {
            SqlCommand crCountriesTable = new SqlCommand(Queries.CREATE_COUNTRIES_TABLE, connToMinonsDB);
            await crCountriesTable.ExecuteNonQueryAsync();
            Console.WriteLine("Table Countries Created!");

            SqlCommand crTownsTable = new SqlCommand(Queries.CREATE_TOWNS_TABLE, connToMinonsDB);
            await crTownsTable.ExecuteNonQueryAsync();
            Console.WriteLine("Table Towns Created!");

            SqlCommand crMinionsTable = new SqlCommand(Queries.CREATE_MINIONS_TABLE, connToMinonsDB);
            await crMinionsTable.ExecuteNonQueryAsync();
            Console.WriteLine("Table Minions Created!");

            SqlCommand crEvilnessFactorsTable = new SqlCommand(Queries.CREATE_EVILNESSFACTORS_TABLE, connToMinonsDB);
            await crEvilnessFactorsTable.ExecuteNonQueryAsync();
            Console.WriteLine("Table EvilnessFactors Created!");

            SqlCommand crVillainsTable = new SqlCommand(Queries.CREATE_VILLAINS_TABLE, connToMinonsDB);
            await crVillainsTable.ExecuteNonQueryAsync();
            Console.WriteLine("Table Villains Created!");

            SqlCommand crMinionsVillainsTable = new SqlCommand(Queries.CREATE_MINIONSVILLAINS_TABLE, connToMinonsDB);
            await crMinionsVillainsTable.ExecuteNonQueryAsync();
            Console.WriteLine("Table MinionsVillains Created!");
        }

        private static async Task InsertIntoTables(SqlConnection connToMinonsDB)
        {
            SqlCommand insIntoCountries = new SqlCommand(Queries.INSERT_INTO_COUNTRIES, connToMinonsDB);
            await insIntoCountries.ExecuteNonQueryAsync();
            Console.WriteLine("Inserted Into Countries!");

            SqlCommand insIntoTowns = new SqlCommand(Queries.INSERT_INTO_TOWNS, connToMinonsDB);
            await insIntoTowns.ExecuteNonQueryAsync();
            Console.WriteLine("Inserted Into Countries!");

            SqlCommand insIntoMinions = new SqlCommand(Queries.INSERT_INTO_MINIONS, connToMinonsDB);
            await insIntoMinions.ExecuteNonQueryAsync();
            Console.WriteLine("Inserted Into Countries!");

            SqlCommand insIntoEvilnessFactors = new SqlCommand(Queries.INSERT_INTO_EVILNESSFACTORS, connToMinonsDB);
            await insIntoEvilnessFactors.ExecuteNonQueryAsync();
            Console.WriteLine("Inserted Into Countries!");

            SqlCommand insIntoVillains = new SqlCommand(Queries.INSERT_INTO_VILLAINS, connToMinonsDB);
            await insIntoVillains.ExecuteNonQueryAsync();
            Console.WriteLine("Inserted Into Countries!");

            SqlCommand insIntoMinionsVillains = new SqlCommand(Queries.INSERT_INTO_MINIONSVILLAINS, connToMinonsDB);
            await insIntoMinionsVillains.ExecuteNonQueryAsync();
            Console.WriteLine("Inserted Into Countries!");
        }
    }
}