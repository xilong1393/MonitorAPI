using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorAPI.Model
{
    public class UserOperationLog
    {
        public int ID { get; set; }
        public string SessionID { get; set; }
        public string Operation { get; set; }
        public DateTime OperationTime { get; set; }
    }
}
