using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MonitorAPI.Service.Operations
{
    public class UDPClientFull : UdpClient
    {
        public UDPClientFull(string ip, int port)
            : base(ip, port)
        {
        }
        public bool Poll(int microSeconds, SelectMode mode)
        {
            return Client.Poll(microSeconds, mode);
        }
    }
    public class SingleCommandProcessor
    {
        const string ZIPERROR = "Zip Data failed";
        const string SENDCOMMANDERROR = "unable send command";
        const string RECEIVERESPONSEERROR = "no response";
        const string PARSERESPONSEERROR = "reponse invalid";

        protected string _ip;
        protected int _port;

        public SingleCommandProcessor(string ip, int port)
        {
            _ip = ip;
            _port = port;
        }
        private byte[] SendBinaryReturnCommand(string commandxml)
        {
            UDPClientFull udpClient = new UDPClientFull(_ip, _port);

            MemoryStream ms = new MemoryStream();
            ICSharpCode.SharpZipLib.Zip.Compression.Streams.DeflaterOutputStream zips = new ICSharpCode.SharpZipLib.Zip.Compression.Streams.DeflaterOutputStream(ms);
            byte[] bytData = System.Text.Encoding.UTF8.GetBytes(commandxml);
            zips.Write(bytData, 0, bytData.Length);
            zips.Close();
            byte[] compressedData = (byte[])ms.ToArray();

            if (udpClient.Send(compressedData, compressedData.Length) == 0)
            {
                throw new Exception("Send Data failed");
            }

            try
            {
                if (!udpClient.Poll(5000000, SelectMode.SelectRead))
                {
                    throw new Exception("in 5 second no response");
                }

                byte[] recvbuf = new byte[2 * 64 * 1024];
                IPEndPoint otherpoint = new IPEndPoint(IPAddress.Any, 0);
                recvbuf = udpClient.Receive(ref otherpoint);
                return recvbuf;
            }
            catch (Exception)
            {
                throw new Exception("failed in waiting for response");
            }
        }
        protected string SendStringReturnCommand(string commandxml)
        {
            byte[] returndata = SendBinaryReturnCommand(commandxml);

            using (System.IO.MemoryStream instream = new System.IO.MemoryStream(returndata))
            {
                instream.Seek(0, System.IO.SeekOrigin.Begin);
                InflaterInputStream requestXMLStream = new InflaterInputStream(instream);
                return new System.IO.StreamReader(requestXMLStream).ReadToEnd();
            }
        }
        protected void SendCommandAndParseResponse(string commandxml)
        {
            string strdata = SendStringReturnCommand(commandxml);
            XMLCommandFactory.ParseReponseXml(strdata);
        }
       
        public virtual Object Execute()
        {
            return null;
        }
    }

    public class UpdateEngineConfiguration : SingleCommandProcessor
    {
        string xml;
        public UpdateEngineConfiguration(string ip, int port, string screenshrinkdeptList, string screenshrinktoSizeInM, UpdateEngineConfigurationParameter parameter)
            : base(ip, port)
        {
            xml = XMLCommandFactory.UpdateEngineConfigurationCommandXml(parameter.IPCIP, parameter.SvrPortalpage, parameter.FTPUser, parameter.FTPPassword, parameter.classroomid, screenshrinkdeptList, screenshrinktoSizeInM);
        }
        public override Object Execute()
        {
            SendCommandAndParseResponse(xml);
            return null;
        }
    }

    public class UpdateAgentConfiguration : SingleCommandProcessor
    {
        string xml;
        public UpdateAgentConfiguration(string ip, int port, UpdateAgentConfigurationParamerer parameter)
            : base(ip, port)
        {
            xml = XMLCommandFactory.UpdateAgentConfigurationCommandXml(parameter.PPCIP, parameter.SvrPortalpage, parameter.classroomid);
        }
        public override Object Execute()
        {
            SendCommandAndParseResponse(xml);
            return null;
        }
    }


    public class RebootPC : SingleCommandProcessor
    {
        public RebootPC(string ip, int port)
            : base(ip, port)
        {
        }
        public override Object Execute()
        {
            string xml = XMLCommandFactory.RebootPCCommandXml();
            SendCommandAndParseResponse(xml);
            return null;
        }
    }
    public class ListLocalData : SingleCommandProcessor {
        public ListLocalData(string ip, int port)
           : base(ip, port)
        {
        }
        public override Object Execute()
        {
            string strresponse = SendStringReturnCommand(XMLCommandFactory.ListLocalDataXml());
            return XMLCommandFactory.ParseLocalDataXml(strresponse);
        }
    }
    public class QuerySchedule : SingleCommandProcessor
    {
        public QuerySchedule(string ip, int port)
            : base(ip, port)
        {
        }
        public override Object Execute()
        {
            string strSchedule = SendStringReturnCommand(XMLCommandFactory.QueryScheduleXml());
            System.Collections.Hashtable CourseSchedule = new Hashtable();
            XMLCommandFactory.ParseScheduleXml(strSchedule, ref CourseSchedule);
            return CourseSchedule;
        }
    }
    public class UpdateEngineConfigurationParameter
    {
        public string IPCIP;
        public string SvrPortalpage;
        public string FTPUser;
        public string FTPPassword;
        public int classroomid;
    }

    public class UpdateAgentConfigurationParamerer
    {
        public string PPCIP;
        public string SvrPortalpage;
        public int classroomid;
    }

}