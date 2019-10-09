using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorAPI.Models.OperationModel
{
    public class TestCourseReturnModel
    {
        public List<Quater> Qlist { get; set; }
        public List<FileServer> Flist { get; set; }
        public List<ClassType> Clist { get; set; }

        public Classroom Classroom { get; set; }

        public TestCourseReturnModel(List<Quater> qlist, List<FileServer> flist, List<ClassType> clist, Classroom classroom)
        {
            this.Qlist = qlist;
            this.Flist = flist;
            this.Clist = clist;
            this.Classroom = classroom;
        }
    }
}