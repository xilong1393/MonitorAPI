using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorAPI.Models.OperationModel
{
    public class ClassroomEngineAgentStatus
    {
        public DateTime? IPCReportTime { get; set; }
        public string AgentVersion { get; set; }
        public string AgentStatus { get; set; }
        public string EngineStatus { get; set; }
        public long? AgentRecordData { get; set; }
        public string ClassroomName { get; set; }
        public string CourseName { get; set; }
        public string ClassroomGroupName { get; set; }
        public int? ClassTypeID { get; set; }

    }
}