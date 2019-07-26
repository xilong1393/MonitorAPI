using System;

namespace MonitorAPI.Model
{
    class ClassroomAgentStatus
    {
        public int ClassroomID { get; set; }

        public DateTime IPCReportTime { get; set; }

        public DateTime AgentVersion { get; set; }

        public string AgentStatus { get; set; }

        public int AgentRecordData { get; set; }
    }
}
