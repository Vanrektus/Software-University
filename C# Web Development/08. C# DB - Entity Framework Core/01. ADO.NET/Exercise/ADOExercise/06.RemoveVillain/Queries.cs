namespace _06.RemoveVillain
{
    public static class Queries
    {
        public const string GET_VILLAIN_NAME = @"SELECT Name FROM Villains WHERE Id = @villainId";

        public const string GET_MINIONS_COUNT = @"SELECT COUNT(*) FROM MinionsVillains WHERE VillainId = @villainId";

        public const string DELETE_FROM_MINIONSVILLAINS = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";
        public const string DELETE_FROM_VILLAINS = @"DELETE FROM Villains WHERE Id = @villainId";
    }
}
