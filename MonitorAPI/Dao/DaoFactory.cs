using MonitorAPI.Dao.framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorAPI.Dao
{
    public class DaoFactory
    {
        private static readonly object padlock = new object();
        private static ClassroomDao classroomDao;
        private static ClassroomGroupDao classroomGroupDao;
        private static LogDao logDao;
        private static UserDao userDao;

        public static ClassroomDao ClassroomDao(PersistenceContext pc)
        {
            if (classroomDao == null) {
                lock (padlock)
                {
                    if (classroomDao == null)
                        classroomDao = new ClassroomDao(pc);
                }
            }
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
            return userDao;
        }

    }
}