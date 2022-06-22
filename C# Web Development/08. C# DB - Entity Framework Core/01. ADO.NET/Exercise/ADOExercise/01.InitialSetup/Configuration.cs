namespace _01.InitialSetup
{
    public static class Configuration
    {
        public const string CONNECTION_MASTER_STRING = @"Server=.;Database=master;
                                                  User Id=sa;Password=SoftUni!2022;
                                                  TrustServerCertificate=True";

        public const string CONNECTION_MINIONSDB_STRING = @"Server=.;Database=MinionsDB;
                                                  User Id=sa;Password=SoftUni!2022;
                                                  TrustServerCertificate=True";
    }
}
