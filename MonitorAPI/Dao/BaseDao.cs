using MonitorAPI.Dao.framework;
using System.Data.SqlClient;

namespace MonitorAPI.Dao
{
    public class BaseDao
    {
        private PersistenceContext persistenceContext;

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
