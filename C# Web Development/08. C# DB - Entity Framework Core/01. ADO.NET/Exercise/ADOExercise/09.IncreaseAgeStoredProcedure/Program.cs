using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace _09.IncreaseAgeStoredProcedure
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());

            SqlConnection connToMinonsDB = new SqlConnection(Configuration.CONNECTION_MINIONSDB_STRING);
            await connToMinonsDB.OpenAsync();

            await using (connToMinonsDB)
            {
                string procedure = "usp_GetOlder";
                SqlCommand getOlderCommand = new SqlCommand(procedure, connToMinonsDB);
                getOlderCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter param = getOlderCommand.Parameters.Add("@id", SqlDbType.Int);
                param.Value = minionId;

                await getOlderCommand.ExecuteNonQueryAsync();

                SqlDataAdapter adapter = new SqlDataAdapter(Queries.GET_MINIONS_INFO, connToMinonsDB);
                DataTable table = new DataTable();
                adapter.SelectCommand.Parameters.AddWithValue("@Id", minionId);

                using (adapter)
                {
                    adapter.Fill(table);
                }

                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"{row[0]} – {row[1]} years old");
                }
            }
        }
    }
}
