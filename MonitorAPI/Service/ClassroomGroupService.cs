using MonitorAPI.Dao;
using MonitorAPI.Dao.framework;
using MonitorAPI.Model;
using MonitorAPI.Util;
using System;
using System.Collections.Generic;

namespace MonitorAPI.Service
{
    public sealed class ClassroomGroupService
    {
        public void CheckSchedule(string sessionID, int classGroupID)
        {
            throw new NotImplementedException();
        }

        public List<ClassroomGroup> GetClassroomGroups(string sessionID)
        {
            using (PersistenceContext pc = new PersistenceContext())
            {
                ClassroomGroupDao classroomGroupDao = DaoFactory.ClassroomGroupDao(pc);
                List<ClassroomGroup> list = classroomGroupDao.GetClassroomGroups();
                return list;
            }
        }

        public List<ClassroomGroup> GetClassroomListByGroupID(string sessionID, int classGroupID)
        {
            throw new NotImplementedException();
        }

        public void GroupSchedule(string sessionID, int classGroupID)
        {
            throw new NotImplementedException();
        }
    }
}