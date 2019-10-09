using MonitorAPI.Dao.framework;

namespace MonitorAPI.Dao
{
    //obselete
    public class DaoFactory
    {
        private static readonly object padlock = new object();
        public static ClassroomDao classroomDao;
        public static ClassroomGroupDao classroomGroupDao;
        public static LogDao logDao;
        public static UserDao userDao;
        public static OperationDao operationDao;

        public static ClassroomDao ClassroomDao(PersistenceContext pc)
        {
            if (classroomDao == null)
            {
                lock (padlock)
                {
                    if (classroomDao == null)
                        classroomDao = new ClassroomDao(pc);
                }
            }
            else
                classroomDao.persistenceContext = pc;

            return classroomDao;
        }

        public static ClassroomGroupDao ClassroomGroupDao(PersistenceContext pc)
        {
            if (classroomGroupDao == null)
            {
                lock (padlock)
                {
                    if (classroomGroupDao == null)
                        classroomGroupDao = new ClassroomGroupDao(pc);
                }
            }
            else
                classroomGroupDao.persistenceContext = pc;

            return classroomGroupDao;
        }

        public static LogDao LogDao(PersistenceContext pc)
        {
            if (logDao == null)
            {
                lock (padlock)
                {
                    if (logDao == null)
                        logDao = new LogDao(pc);
                }
            }
            else
                logDao.persistenceContext = pc;

            return logDao;
        }

        public static UserDao UserDao(PersistenceContext pc)
        {
            if (userDao == null)
            {
                lock (padlock)
                {
                    if (userDao == null)
                        userDao = new UserDao(pc);
                }
            }
            else
                userDao.persistenceContext = pc;

            return userDao;
        }

        public static OperationDao OperationDao(PersistenceContext pc)
        {
            if (operationDao == null)
            {
                lock (padlock)
                {
                    if (operationDao == null)
                        operationDao = new OperationDao(pc);
                }
            }
            else
                operationDao.persistenceContext = pc;

            return operationDao;
        }
    }
}