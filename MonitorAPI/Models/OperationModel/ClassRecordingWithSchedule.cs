using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorAPI.Models.OperationModel
{
    public class ClassRecordingWithSchedule
    {
        public string ClassName { get; set; }
        public bool IsPeriodicCourse { get; set; }
        public int ClassLength { get; set; }
        public int FileServerID { get; set; }
        public int ClassTypeID { get; set; }
        public int ClassroomID { get; set; }
        public int ClassID { get; set; }
        public string ClassDataDir { get; set; }
        public string FileServerName { get; set; }
        public DateTime classstarttime { get; set; }
        public string InstructorName { get; set; }
        public int QuarterID { get; set; }
        public bool IsPostDelay { get; set; }
        public bool IsPodcast { get; set; }
        public string ClassroomName { get; set; }
    }
}