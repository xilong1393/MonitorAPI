using System;
using System.Data;

namespace MonitorAPI.Service.Operations
{
    public class PushSchedule : SingleCommandProcessor
    {
        private DataTable CourseSchedule;
        public PushSchedule(string ip, int port, DataTable dtSchedule)
            : base(ip, port)
        {
            CourseSchedule = dtSchedule;
        }
        public override Object Execute()
        {
            string xml = XMLCommandFactory.PushScheduleXml(CourseSchedule);
            SendCommandAndParseResponse(xml);
            return CourseSchedule;
        }
    }
}