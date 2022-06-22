namespace _04.AddMinion
{
    public static class Queries
    {
        public const string GET_VILLAIN_ID = @"SELECT Id FROM Villains WHERE Name = @villainName";
        public const string GET_MINION_ID = @"SELECT Id FROM Minions WHERE Name = @minionName";
        public const string GET_TOWN_ID = @"SELECT Id FROM Towns WHERE Name = @townName";

        public const string INSERT_INTO_MINIONSVILLAINS = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
        public const string INSERT_INTO_VILLAINS = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
        public const string INSERT_INTO_MINIONS = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@minionName, @age, @townId)";
        public const string INSERT_INTO_TOWNS = @"INSERT INTO Towns (Name) VALUES (@townName)";
    }
}
