using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorAPI.Model
{
    public class ClassroomView
    {
        [Browsable(false)]
        public int ClassroomID { get; set; }
        public string PPCPublicIP { get; set; }
        public int PPCPort { get; set; }
        public string ClassroomName { get; set; }
        public string EngineStatus { get; set; }
        public string AgentStatus { get; set; }
        [DisplayName("PPC")]
        public string PPCConnectionStatus { get; set; }
        //course
        public string AVStatus { get; set; }
        public int WBNumber { get; set; }
        public string Status { get; set; }
        //SD
        public int FreeDisk { get; set; }
    }
}
