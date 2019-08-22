using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorAPI.Service.Operations
{
    public class StopRecord : SingleCommandProcessor
    {
        public StopRecord(string ip, int port) : base(ip, port)
        {
        }

        public override object Execute()
        {
            string xml = XMLCommandFactory.StopCommandXml();
            SendCommandAndParseResponse(xml);
            return null;
        }
    }
}