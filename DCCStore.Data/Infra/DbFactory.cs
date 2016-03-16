namespace DCCStore.Data
{
    public class DbFactory : Disposable, IDbFactory
    {
        DCCScoreDbEntities dbContext;

        public DCCScoreDbEntities Init()
        {
            return dbContext ?? (dbContext = new DCCScoreDbEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null) dbContext.Dispose();
        }
    }
}
