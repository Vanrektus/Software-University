namespace _03.MinionNames
{
    public static class Queries
    {
        public const string GET_VILLAINS_NAMES = @"SELECT Name FROM Villains WHERE Id = @VillainId";

        public const string GET_MINIONS_INFO =
            @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                     m.Name, 
                     m.Age
                FROM MinionsVillains AS mv
                JOIN Minions As m ON mv.MinionId = m.Id
               WHERE mv.VillainId = @VillainId
            ORDER BY m.Name";
    }
}
