using MonitorAPI.Dao;
using MonitorAPI.Dao.framework;
using MonitorAPI.Model;
using System;

namespace MonitorAPI.Service
{
    public sealed class UserService
    {
        UserService() { }
        private static readonly object padlock = new object();
        private static UserService instance = null;
        public static UserService Instance {
            get {
                if (instance == null) {
                    lock (padlock) {
                        if (instance == null)
                        {
                            instance = new UserService();
                        }
                    }
                }
                return instance;
            }
        }
        public void LogUserLogin(string sessionID, string employerID, DateTime loginTime, string loginID)
        {
            throw new NotImplementedException();
        }

        public void LogUserOperation(string sessionID, string operation, DateTime operationTime)
        {
            throw new NotImplementedException();
        }

        public User UserLogin(string userName, string password)
        {
            using (PersistenceContext pc = new PersistenceContext())
            {
                UserDao userDao = new UserDao(pc);
                User user = userDao.GetUser(userName, password);
                return user;
            }
        }
    }
}
