using MonitorAPI.Dao;
using MonitorAPI.Dao.framework;
using MonitorAPI.Model;
using MonitorAPI.Models;
using MonitorAPI.Models.OperationModel;
using System;
using System.Collections.Generic;

namespace MonitorAPI.Service
{
    public sealed class ClassroomService
    {
        public void AbortCourse(string sessionID, int classID)
        {
            throw new NotImplementedException();
        }

        public ClassroomInfo GetClassroomInfo(string sessionID, int classID)
        {
            using (PersistenceContext pc = new PersistenceContext())
            {
                ClassroomDao classroomDao = new ClassroomDao(pc);
                ClassroomInfo classroomInfo = classroomDao.GetClassroomInfoByID(classID);
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

        public List<ClassroomScheduleView> GetClassroomScheduleByGroupID(string sessionID, int classGroupID)
        {
            using (PersistenceContext pc = new PersistenceContext())
            {
                ClassroomDao classroomDao = new ClassroomDao(pc);
                List<ClassroomScheduleView> list = classroomDao.GetClassroomScheduleByGroupID(classGroupID);
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

        internal Classroom GetClassroomByID(int classroomid)
        {
            using (PersistenceContext pc = new PersistenceContext())
            {
                ClassroomDao classroomDao = new ClassroomDao(pc);
                Classroom classroom = classroomDao.GetClassroomByID(classroomid);
                return classroom;
            }
        }

        public ClassroomInfoView GetClassroomDetailByGroupID(string sessionID, int classroomID)
        {
            using (PersistenceContext pc = new PersistenceContext())
            {
                ClassroomDao classroomDao = new ClassroomDao(pc);
                ClassroomInfoView classroomView = classroomDao.GetClassroomDetailByID(classroomID);
                return classroomView;
            }
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
