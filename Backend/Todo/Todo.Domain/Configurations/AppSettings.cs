namespace Todo.Domain.Configurations
{
    internal sealed class AppSettings
    {
        private string Issuer { get; init; } = "Todo";
        private string DbHost { get; init; } = "localhost";
        private string DbUsername { get; init; } = "postgres";
        private string DbPassword { get; init; } = "root";
        private string Db { get; init; } = "todo_db";

        public string GetIssuer()
        {
            return Issuer;
        }

        public string GetDbConnectionString()
        {
            return "Host=" + DbHost + ";Username=" + DbUsername + ";Password=" + DbPassword +
                ";Database=" + Db;
        }
    }
}
