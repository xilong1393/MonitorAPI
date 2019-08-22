using MonitorAPI.Dao.framework;
using System.Data.SqlClient;

namespace MonitorAPI.Dao
{
    public class BaseDao
    {
        public PersistenceContext persistenceContext;

        protected SqlConnection Connection
        {
            get
            {
                return persistenceContext.Connection;
            }
        }
        protected BaseDao(PersistenceContext persistenceContext)
        {
            this.persistenceContext = persistenceContext;
        }
    }
}
