namespace DBAccess.DalImplementation
{
    public class HistoryTravelService : IHistoryRepository
    {
        public bool Exists()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<HistoryRow> GetAppliedMigrations()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<HistoryRow>> GetAppliedMigrationsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public string GetBeginIfExistsScript(string migrationId)
        {
            throw new NotImplementedException();
        }

        public string GetBeginIfNotExistsScript(string migrationId)
        {
            throw new NotImplementedException();
        }

        public string GetCreateIfNotExistsScript()
        {
            throw new NotImplementedException();
        }

        public string GetCreateScript()
        {
            throw new NotImplementedException();
        }

        public string GetDeleteScript(string migrationId)
        {
            throw new NotImplementedException();
        }

        public string GetEndIfScript()
        {
            throw new NotImplementedException();
        }

        public string GetInsertScript(HistoryRow row)
        {
            throw new NotImplementedException();
        }
    }
}
