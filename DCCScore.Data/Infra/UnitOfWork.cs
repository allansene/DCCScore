using System;

namespace DCCScore.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private DCCScoreDbEntities dbContext;

        public UnitOfWork(DCCScoreDbEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public DCCScoreDbEntities DbContext
        {
            get { return dbContext; }
        }
        public void Commit()
        {
            DbContext.Commit();
        }
    }

}
