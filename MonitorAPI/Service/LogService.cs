using MonitorAPI.Dao;
using MonitorAPI.Dao.framework;
using MonitorAPI.Model;
using System.Transactions;

namespace MonitorAPI.Service
{
    public sealed class LogService
    {
        public bool LogUserLogin(UserLoginLog userLoginLog)
        {
            using (PersistenceContext pc = new PersistenceContext(IsolationLevel.ReadCommitted)) {
                LogDao dao = new LogDao(pc);
                bool result = dao.InsertUserLogin(userLoginLog);
                if (result) pc.Commit();
                return result;
            }
        }

        public bool LogUserOperation(UserOperationLog userOperationLog)
        {
            using (PersistenceContext pc = new PersistenceContext(IsolationLevel.ReadCommitted))
            {
                LogDao dao = new LogDao(pc);
                bool result = dao.InsertUserOperation(userOperationLog);
                if (result) pc.Commit();
                return result;
            }
        }
    }
}
