using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MonitorAPI.Models
{
    public class ClassroomInfoView
    {
        [Browsable(false)]
        public int ClassroomID { get; set; }
        public string ClassroomName { get; set; }
        public string EngineStatus { get; set; }
        [DisplayName("PPCIP")]
        public string PPCPublicIP { get; set; }
        [DisplayName("IPCIP")]
        public string IPCPublicIP { get; set; }

        public string AgentStatus { get; set; }
        public string PPCConnectionStatus { get; set; }
        //course
        public string AVStatus { get; set; }
        public int WBNumber { get; set; }
        public string Status { get; set; }
        //SD
        public int FreeDisk { get; set; }
    }
}