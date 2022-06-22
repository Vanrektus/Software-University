using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace _07.PrintAllMinionNames
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SqlConnection connToMinonsDB = new SqlConnection(Configuration.CONNECTION_MINIONSDB_STRING);
            await connToMinonsDB.OpenAsync();

            await using (connToMinonsDB)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(Queries.GET_MINIONS_NAMES, connToMinonsDB);
                DataTable table = new DataTable();

                using (adapter)
                {
                    adapter.Fill(table);
                }

                int counter = 0;

                while (counter <= ((table.Rows.Count - 1) / 2))
                {
                    DataRow nextFromFirst = table.Rows[0 + counter];
                    DataRow beforeFromLast = table.Rows[table.Rows.Count - 1 - counter];
                    Console.WriteLine(nextFromFirst[0]);
                    if (table.Rows.Count % 2 != 0 && counter == (table.Rows.Count - 1) / 2)
                    {
                        counter++;
                        continue;
                    }

                    Console.WriteLine(beforeFromLast[0]);
                    counter++;
                }
            }
        }
    }
}
