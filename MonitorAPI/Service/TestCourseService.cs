using MonitorAPI.Dao;
using MonitorAPI.Dao.framework;
using MonitorAPI.Models.OperationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorAPI.Service
{
    public class TestCourseService
    {
        public List<Quater> GetAllQuarter()
        {
            using (PersistenceContext pc = new PersistenceContext())
            {
                TestCourseDao dao = new TestCourseDao(pc);
                return dao.GetAllQuarter();
            }
        }

        public List<ClassType> GetAllClassType()
        {
            using (PersistenceContext pc = new PersistenceContext())
            {
                TestCourseDao dao = new TestCourseDao(pc);
                return dao.GetAllClassType();
            }
        }

        public List<FileServer> GetAllFileServer()
        {
            using (PersistenceContext pc = new PersistenceContext())
            {
                TestCourseDao dao = new TestCourseDao(pc);
                return dao.GetAllFileServer();
            }
        }

    }
}