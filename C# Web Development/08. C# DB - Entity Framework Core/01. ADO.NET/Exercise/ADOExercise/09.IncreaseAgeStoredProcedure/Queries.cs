namespace _09.IncreaseAgeStoredProcedure
{
    public static class Queries
    {
        public const string CREATE_GETOLDER_PROCEDURE = 
            @"CREATE PROC usp_GetOlder @id INT
              AS
              UPDATE Minions
                 SET Age += 1
               WHERE Id = @id";

        public const string GET_MINIONS_INFO = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
    }
}
