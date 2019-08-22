using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorAPI.Service.Operations
{
    public class AbortRecord : SingleCommandProcessor
    {
        public AbortRecord(string ip, int port) : base(ip, port)
        {
        }

        public override object Execute()
        {
            string xml = XMLCommandFactory.AbortCommandXml();
            SendCommandAndParseResponse(xml);
            return null;
        }
    }
}