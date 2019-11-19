using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MonitorAPI.Models.OperationModel
{
    public class ClassroomScheduleView
    {
        //public string PPCPUBLICIP { get; set; }
        public string ClassroomName { get; set; }
        public string ClassName { get; set; }
        public string InstructorName { get; set; }
        public int WeekDayID { get; set; }
        public DateTime ClassStartTime { get; set; }
        public int ClassLength { get; set; }

        //public string PPCPort { get; set; }
    }
}