namespace ORM
{
    public sealed class Settings
    {
        private string databaseServerName;

        private string databaseName;

        public void AddDatabaseServer(string serverName)
        {
            this.databaseServerName = serverName;
            //this.configuration.AppSettings.Settings.Add(ServerNameKey, serverName);
        }

        public string GetDatabaseServer()
        {
            return this.databaseServerName;
            //return this.configuration.AppSettings.Settings[ServerNameKey].Value;
        }

        public void AddDatabaseName(string databaseName)
        {
            this.databaseName = databaseName;
        }

        public string GetDatabaseName()
        {
            return this.databaseName;
        }
    }
}
