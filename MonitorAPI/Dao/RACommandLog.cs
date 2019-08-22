using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorAPI.Dao
{
    public class RACommandLog
    {
        public int LogID { get; set; }
        public string Application { get; set; }
        public string IP { get; set; }
        public string Command { get; set; }
        public string Classroom { get; set; }
        public DateTime OperationTime { get; set; }
        public char CommandStatus { get; set; }
    }
}