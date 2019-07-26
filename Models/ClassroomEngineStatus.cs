using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorAPI.Model
{
    class ClassroomEngineStatus
    {
        public int ClassroomID { get; set; }

        public DateTime PPCReportTime { get; set; }

        public DateTime EngineVersion { get; set; }

        public string EngineStatus { get; set; }

        public string AVStatus { get; set; }
        public int AVCaputureFrames { get; set; }
        public string CameraStatus { get; set; }
        public string WBStatus { get; set; }
        public int WBNumber { get; set; }
        public int SGStatus { get; set; }

        public int SSStatus { get; set; }

        public string PPCIP { get; set; }
        public string IPCIP { get; set; }
        public string PPCConnectionStatus { get; set; }

        public bool IPCConnectionStatus { get; set; }

        public string SvrPortalpage { get; set; }
        public int FreeDisk { get; set; }
        public string CourseName { get; set; }
        public int CourseID { get; set; }

    }
   
}
