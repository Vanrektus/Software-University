namespace _05.ChangeTownNamesCasing
{
    public static class Queries
    {
        public const string UPDATE_TOWNS =
            @"UPDATE Towns
                 SET Name = UPPER(Name)
               WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

        public const string GET_TOWNS =
            @" SELECT t.Name 
                 FROM Towns as t
                 JOIN Countries AS c ON c.Id = t.CountryCode
                WHERE c.Name = @countryName";
    }
}
