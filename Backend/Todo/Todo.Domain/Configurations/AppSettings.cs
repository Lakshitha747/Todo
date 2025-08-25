namespace Todo.Domain.Configurations
{
    internal sealed class AppSettings
    {
        private bool Production { get; init; } = false;
        private string Issuer { get; init; } = "Todo";

        //local db
        private string LocalDbHost { get; init; } = "localhost";
        private string LocalDbUsername { get; init; } = "postgres";
        private string LocalDbPassword { get; init; } = "root";
        private string LocalDb { get; init; } = "todo_db";

        //prod db
        private string ProdDbHost { get; init; } = "postgres";
        private string ProdDbUsername { get; init; } = "postgres";
        private string ProdDbPassword { get; init; } = "postgres";
        private string ProdDb { get; init; } = "todo_db";
        public AppSettings(bool production)
        {
            Production = production;
        }

        public string GetIssuer()
        {
            return Issuer;
        }

        public string GetDbConnectionString()
        {
            return Production
                ? "Host=" + ProdDbHost + ";Username=" + ProdDbUsername + ";Password=" + ProdDbPassword + ";Database=" + ProdDb
                : "Host=" + LocalDbHost + ";Username=" + LocalDbUsername + ";Password=" + LocalDbPassword + ";Database=" + LocalDb;
        }
    }
}
