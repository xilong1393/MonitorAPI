using MonitorAPI.Dao;
using MonitorAPI.Dao.framework;
using MonitorAPI.Model;
using System;
using System.Collections.Generic;

namespace MonitorAPI.Service
{
    public sealed class ClassroomService
    {
        ClassroomService() { }
        private static readonly object padlock = new object();
        private static ClassroomService instance = null;
        public static ClassroomService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new ClassroomService();
                        }
                    }
                }
                return instance;
            }
        }
        public void AbortCourse(string sessionID, int classID)
        {
            throw new NotImplementedException();
        }

        public ClassroomInfo GetClassroomInfo(string sessionID, int classID)
        {
            using (PersistenceContext pc = new PersistenceContext())
            {
                ClassroomDao classroomDao = new ClassroomDao(pc);
                ClassroomInfo classroomInfo = classroomDao.GetClassroomID(classID);
                return classroomInfo;
            }
        }

        public List<ClassroomView> GetClassroomListByGroupID(string sessionID, int classGroupID)
        {
            using (PersistenceContext pc = new PersistenceContext())
            {
                ClassroomDao classroomDao = new ClassroomDao(pc);
                List<ClassroomView> list = classroomDao.GetClassroomByGroupID(classGroupID);
                return list;
            }
        }

        public void ListLocalData(string sessionID, int classID)
        {
            throw new NotImplementedException();
        }

        public void PushConfig(string sessionID, int classID)
        {
            throw new NotImplementedException();
        }

        public void PushSchedule(string sessionID, int classroomID)
        {
            throw new NotImplementedException();
        }

        public void RebootIPC(string sessionID, int classID)
        {
            throw new NotImplementedException();
        }

        public void RebootPPC(string sessionID, int classID)
        {
            throw new NotImplementedException();
        }

        public void StartTestCourse(string sessionID, int classID)
        {
            throw new NotImplementedException();
        }

        public void StopCourse(string sessionID, int classID)
        {
            throw new NotImplementedException();
        }
    }
}
