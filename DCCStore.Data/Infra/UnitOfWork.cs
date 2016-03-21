using System;

namespace DCCScore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private DCCScoreDbEntities dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public DCCScoreDbEntities DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }
        public void Commit()
        {
            DbContext.Commit();
        }
    }

}
