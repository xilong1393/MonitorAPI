using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

namespace MonitorAPI.Service.Operations
{
    public class XMLCommandFactory
    {
        private const string PROTOCOL_VERSION_STR = "version";
        private const string PROTOCOL_VERSION_VALUE = "04.00.00";

        private const string XML_VERSION_STR = "1.0";

        private const string UTF_VSESION_STR = "UTF-8";

        private const int PROTOCOL_RESPONSE_ID = 5;

        private const string EVENT_REPORT_ID = "11";

        private const string RESPONSE_SUCC_STR = "Succeed";
        private const string RESPONSE_FAILED_STR = "Failed";
        private const string RESPONSE_GOT_STR = "Got";


        private const string RESPONSE_COMMAND_STR = "col-response";


        private const string SCHEDULE_HEAD_TAG_STR = "col-schedule";
        private const int NEW_SCHEDULE_COMMAND_ID = 3;
        private const string NEW_SCHEDULE_COMMAND_STR = "colengine-new-schedule";

        private const int STOP_COMMAND_ID = 6;
        private const string STOP_COMMAND_STR = "colengine-stop-recording";

        private const int ABORT_COMMAND_ID = 7;
        private const string ABORT_COMMAND_STR = "colengine-abort-recording";

        private const int QUERY_ENGINE_STATUS_ID = 8;
        private const string QUERY_ENGINE_STATUS_STR = "colengine-status-report";

        private const int ENGINE_UPLOADED_STATUS_ID = 17;
        private const string ENGINE_UPLOADED_STATUS_STR = "uploaded";
        private const string ENGINE_UPLOADED_FLAG_STR = "Yes";


        private const int UPDATEENGINECONFIGURATION_COMMAND_ID = 9;
        private const string UPDATEENGINECONFIGURATION_COMMAND_STR = "colengine-update-config";

        private const string UPDATEAGENTCONFIGURATION_COMMAND_STR = "colagent-update-config";
        private const int UPDATEAGENTCONFIGURATION_COMMAND_ID = 24;

        private const int LIST_LOCALDATA_COMMAND_ID = 12;
        private const int LIST_LOCALDATA_REPONSE_ID = 13;
        private const string LIST_LOCALDATA_COMMAND_STR = "colengine-list-localdata";

        private const int DEL_LOCALDATA_COMMAND_ID = 14;
        private const string DEL_LOCALDATA_COMMAND_STR = "colengine-deletedata";

        private const int QUERY_IMAGE_TYPE_ID = 19;
        private const string QUERY_IMAGE_TYPE_STR = "colengine-query-image";

        private const int UPLOAD_LOCALDATA_COMMAND_ID = 20;
        private const string UPLOAD_LOCALDATA_COMMAND_STR = "colengine-upload-data";

        private const int REBOOTPC_COMMAND_ID = 22;
        private const string REBOOTPC_COMMAND_STR = "colengine-reboot-pc";

        private const int QUERY_AGENT_STATUS_ID = 25;
        private const string QUERY_AGENT_STATUS_STR = "colagent-status-report";

        private const int QUERY_AUDIO_COMMAND_ID = 26;
        private const string QUERY_AUDIO_COMMAND_STR = "colengine-query-audio";

        private const int QUERY_SCHEDULE_COMMAND_ID = 27;
        private const string QUERY_SCHEDULE_COMMAND_STR = "colegine_courseschedule_report";

        private const string SCHEDULE_TIMESTAMP_STR = "timestamp";
        private const string SERVER_STR = "server";

        private const string PROCESSING_STR = "postprocessing";
        private const string DELAY_STR = "delay";

        private const string WHITEBOARD_STR = "whiteboard";
        private const string WB_NUM_STR = "wb-num";
        private const string INTERVAL_STR = "interval";

        private const string FTP_STR = "ftp";
        private const string UPLOADING_STR = "uploading";
        private const string USER_STR = "user";
        private const string PASSWORD_STR = "password";
        private const string INSTRUCTOR_PC_STR = "instructor-pc";

        private const string IP_STR = "ip";
        private const string PORTAL_PAGE_STR = "portal-page";
        private const string CLASSROOMID_STR = "classroomid";
        private const string PPC_STR = "ppc";
        private const string DIRECTORY_STR = "directory";

        private const string SCREENSHOT_STR = "screenshot";
        private const string COURSE_INFO_STR = "course-info";
        private const string ID_STR = "id";
        private const string PPCIP_STR = "PPCIP";
        private const string IPC_STR = "ipc";
        private const string DATAVERSION_STR = "data-version";

        private const string RATE_STR = "rate";
        private const string WIDTH_STR = "width";
        private const string HEIGHT_STR = "height";
        private const string VIDEO_STR = "video";
        private const string HI_VIDEO_STR = "hi-video";
        private const string LO_VIDEO_STR = "lo-video";

        private const string H_DIVIDE_STR = "h-divide";
        private const string V_DIVIDE_STR = "v-divide";
        private const string HI_COLORBITS_STR = "hi-colorbits";
        private const string LO_COLORBITS_STR = "lo-colorbits";
        private const string CHOP_LEN_STR = "chop-len";
        private const string DENOISE_STR = "denoise";
        private const string IMAGE_INTERVCAL_STR = "image-interval";

        private const string START_TIME_STR = "start-time";
        private const string DURATION_STR = "duration";
        private const string START_TIMER_STR = "start-timer";

        private const string NAME_STR = "name";
        private const string TYPE_STR = "type";

        private const int INSTRUCTOR_SENDMESSAGE_COMMAND_ID = 101;
        private const string INSTRUCTOR_SENDMESSAGE_COMMAND_STR = "instructor-instant-message-response";
        private const string INSTRUCTOR_SENDMESSAGE_ATTR_MESSAGE = "message";
        private const string INSTRUCTOR_SENDMESSAGE_ATTR_SENDER = "sender";

        private const string INSTRUCTOR_SET_CLASS_ATTR_SETVALUE = "setvalue";

        private const string ScreenShrinkDeptList_STR = "screenshrinkdeptlist";
        private const string ScreenShrinkToSizeInM_STR = "screenshrinktosizeinm";

        internal static string PushScheduleXml(DataTable courseSchedule)
        {
            return pushschedule_command_xml(NEW_SCHEDULE_COMMAND_STR, NEW_SCHEDULE_COMMAND_ID, courseSchedule);
        }

        static public string StopCommandXml()
        {
            return simple_command_xml(STOP_COMMAND_STR, STOP_COMMAND_ID);
        }
        static public string AbortCommandXml()
        {
            return simple_command_xml(ABORT_COMMAND_STR, ABORT_COMMAND_ID);
        }
        static public string RebootPCCommandXml()
        {
            return simple_command_xml(REBOOTPC_COMMAND_STR, REBOOTPC_COMMAND_ID);
        }
        static public string ListLocalDataXml()
        {
            return simple_command_xml(LIST_LOCALDATA_COMMAND_STR, LIST_LOCALDATA_COMMAND_ID);
        }

        static public string QueryScheduleXml()
        {
            return simple_command_xml(QUERY_SCHEDULE_COMMAND_STR, QUERY_SCHEDULE_COMMAND_ID);
        }
        static public ArrayList ParseLocalDataXml(string datalistxml)
        {
            ArrayList dirnames = new ArrayList();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(datalistxml);

                foreach (XmlNode childnode in doc)
                {
                    if (childnode.NodeType == XmlNodeType.Element)
                    {
                        if (childnode.Attributes[PROTOCOL_VERSION_STR].Value != PROTOCOL_VERSION_VALUE)
                        {
                            throw new Exception("version is not correct, version=" + childnode.Attributes[PROTOCOL_VERSION_STR].Value);
                        }
                        if (childnode.Attributes[ID_STR].Value != LIST_LOCALDATA_REPONSE_ID.ToString())
                        {
                            throw new Exception("response id is not correct, responseid=" + childnode.Attributes[ID_STR].Value);
                        }
                        foreach (XmlNode namenode in childnode)
                        {
                            if (namenode.Name.ToLower() == DIRECTORY_STR)
                            {
                                string value1 = namenode.InnerText;
                                dirnames.Add(value1);
                            }
                        }
                    }
                }

            }
            catch (Exception e1)
            {
                throw new Exception("parse exception, error: " + e1.ToString() + "\r\n" + " xml: " + datalistxml);
            }
            return dirnames;
        }

        static public string UpdateEngineConfigurationCommandXml(string IPCIP, string SvrPortalpage, string FTPUser, string FTPPassword, int classroomid, String screenshrinkdeptList, string screenshrinktoSizeInM)
        {
            return updateengineconfiguration_command_xml(UPDATEENGINECONFIGURATION_COMMAND_STR, UPDATEENGINECONFIGURATION_COMMAND_ID, IPCIP, SvrPortalpage, FTPUser, FTPPassword, classroomid, screenshrinkdeptList, screenshrinktoSizeInM);
        }
        static public string GetImageString(string IPCIP, string SvrPortalpage, string FTPUser, string FTPPassword, int classroomid, String screenshrinkdeptList, string screenshrinktoSizeInM)
        {
            return updateengineconfiguration_command_xml(QUERY_IMAGE_TYPE_STR, QUERY_IMAGE_TYPE_ID, IPCIP, SvrPortalpage, FTPUser, FTPPassword, classroomid, screenshrinkdeptList, screenshrinktoSizeInM);
        }
        static public string UpdateAgentConfigurationCommandXml(string PPCIP, string SvrPortalpage, int classroomid)
        {
            return updateagentconfiguration_command_xml(UPDATEAGENTCONFIGURATION_COMMAND_STR, UPDATEAGENTCONFIGURATION_COMMAND_ID, PPCIP, SvrPortalpage, classroomid);
        }

        static private string simple_command_xml(string commandname, int commandid)
        {
            XmlDocument doc = simple_command_xml_base(commandname, commandid);
            return doc.OuterXml;
        }
        static private XmlDocument simple_command_xml_base(string commandname, int commandid)
        {
            XmlDocument doc = create_node_document();
            XmlNode commandNode = doc.CreateElement(commandname);
            append_XmlNode_VersionAndCommandID(doc, commandNode, commandid);

            doc.AppendChild(commandNode);
            return doc;
        }
        static private string pushschedule_command_xml(string commandname, int commandid, System.Data.DataTable CourseSchedule)
        {
            XmlDocument doc = create_node_document();
            XmlNode schedulenode = doc.CreateElement(commandname);
            append_XmlNode_VersionAndCommandID(doc, schedulenode, commandid);
            append_XmlNode_attribute(doc, schedulenode, SCHEDULE_TIMESTAMP_STR, DateTime.Now.ToString("MM dd yyyy HH mm ss"));
            doc.AppendChild(schedulenode);
            foreach (DataRow drschedule in CourseSchedule.Rows)//need deal with distinct
            {
                CourseInfo courseinfo = new CourseInfo();
                CourseRecordInfo courserecord = new CourseRecordInfo();
                courseinfo.intCourseId = Convert.ToInt32(drschedule["classid"]);
                if (Convert.ToBoolean(drschedule["IsPostDelay"]) == false)
                {
                    courseinfo.intProcess_delay = 0;
                }
                else
                {
                    courseinfo.intProcess_delay = -1;
                }
                courseinfo.intChop_length = 400;
                courseinfo.strCourseName = drschedule["classname"].ToString();
                courseinfo.intType = Convert.ToInt32(drschedule["ClassTypeID"]);
                courseinfo.strDataPath = drschedule["ClassDataDir"].ToString();
                courseinfo.strFTPHost = drschedule["FileServerName"].ToString();
                courserecord.datetimeStartTime = System.Convert.ToDateTime(drschedule["classstarttime"].ToString()); //drschedule[DataColumn 
                courserecord.intLength = Convert.ToInt32(drschedule["ClassLength"]);
                schedulenode.AppendChild(addonecourseinschedule(ref doc, courserecord, courseinfo));
            }
            return doc.OuterXml;
        }

        static private XmlDocument create_node_document()
        {
            XmlDocument doc = new XmlDocument();

            XmlNode docNode = doc.CreateXmlDeclaration(XML_VERSION_STR, UTF_VSESION_STR, null);
            doc.AppendChild(docNode);
            return doc;
        }
        static private void append_XmlNode_VersionAndCommandID(XmlDocument doc, XmlNode node, int commandid)
        {
            append_XmlNode_attribute(doc, node, PROTOCOL_VERSION_STR, PROTOCOL_VERSION_VALUE);
            append_XmlNode_attribute(doc, node, ID_STR, commandid.ToString());
        }
        static private void append_XmlNode_attribute(XmlDocument doc, XmlNode node, string attrname, string attrvalue)
        {
            XmlAttribute attr = doc.CreateAttribute(attrname);
            attr.Value = attrvalue;
            node.Attributes.Append(attr);
        }
        static private XmlNode addonecourseinschedule(ref XmlDocument doc, CourseRecordInfo rinfo, CourseInfo cinfo)
        {
            //----class node
            XmlNode node = doc.CreateElement("class");

            append_XmlNode_attribute(doc, node, START_TIME_STR, rinfo.datetimeStartTime.ToString("MM dd yyyy HH mm ss"));
            append_XmlNode_attribute(doc, node, DURATION_STR, rinfo.intLength.ToString());
            append_XmlNode_attribute(doc, node, START_TIMER_STR, rinfo.intStartTimer.ToString());

            //-- course-info node
            XmlNode courseinfoNode = doc.CreateElement(COURSE_INFO_STR);
            append_XmlNode_attribute(doc, courseinfoNode, ID_STR, cinfo.intCourseId.ToString());
            append_XmlNode_attribute(doc, courseinfoNode, NAME_STR, cinfo.strCourseName);
            append_XmlNode_attribute(doc, courseinfoNode, TYPE_STR, cinfo.intType.ToString());
            node.AppendChild(courseinfoNode);

            //-- ftp
            XmlNode ftpNode = doc.CreateElement(FTP_STR);
            append_XmlNode_attribute(doc, ftpNode, SERVER_STR, cinfo.strFTPHost);
            append_XmlNode_attribute(doc, ftpNode, DIRECTORY_STR, cinfo.strDataPath);
            node.AppendChild(ftpNode);

            //-- screenshot
            XmlNode scNode = doc.CreateElement(SCREENSHOT_STR);
            append_XmlNode_attribute(doc, scNode, INTERVAL_STR, cinfo.intSCInterval.ToString());
            append_XmlNode_attribute(doc, scNode, WIDTH_STR, cinfo.intSCWidth.ToString());
            append_XmlNode_attribute(doc, scNode, HEIGHT_STR, cinfo.intSCWidth.ToString());
            append_XmlNode_attribute(doc, scNode, H_DIVIDE_STR, cinfo.intSCHDivide.ToString());
            append_XmlNode_attribute(doc, scNode, V_DIVIDE_STR, cinfo.intSCVDivide.ToString());
            append_XmlNode_attribute(doc, scNode, HI_COLORBITS_STR, cinfo.intSC_hcolorbits.ToString());
            append_XmlNode_attribute(doc, scNode, LO_COLORBITS_STR, cinfo.intSC_lcolorbits.ToString());
            node.AppendChild(scNode);

            //---video
            XmlNode videoNode = doc.CreateElement(VIDEO_STR);
            append_XmlNode_attribute(doc, videoNode, CHOP_LEN_STR, cinfo.intChop_length.ToString());
            append_XmlNode_attribute(doc, videoNode, DENOISE_STR, cinfo.intDenoise.ToString());

            //--video high
            XmlNode hvideoNode = doc.CreateElement(HI_VIDEO_STR);
            append_XmlNode_attribute(doc, hvideoNode, RATE_STR, cinfo.intHVideo_rate.ToString());
            append_XmlNode_attribute(doc, hvideoNode, WIDTH_STR, cinfo.intHVideo_width.ToString());
            append_XmlNode_attribute(doc, hvideoNode, HEIGHT_STR, cinfo.intLVideo_height.ToString());

            videoNode.AppendChild(hvideoNode);

            //--video low
            XmlNode lvideoNode = doc.CreateElement(LO_VIDEO_STR);
            append_XmlNode_attribute(doc, lvideoNode, RATE_STR, cinfo.intLVideo_rate.ToString());
            append_XmlNode_attribute(doc, lvideoNode, WIDTH_STR, cinfo.intLVideo_width.ToString());
            append_XmlNode_attribute(doc, lvideoNode, HEIGHT_STR, cinfo.intLVideo_height.ToString());
            append_XmlNode_attribute(doc, lvideoNode, IMAGE_INTERVCAL_STR, cinfo.intlvideo_img_interval.ToString());

            videoNode.AppendChild(lvideoNode);

            node.AppendChild(videoNode);

            //-- whiteboard
            XmlNode wbNode = doc.CreateElement(WHITEBOARD_STR);
            append_XmlNode_attribute(doc, wbNode, INTERVAL_STR, cinfo.intWB_interval.ToString());

            node.AppendChild(wbNode);

            //--postprocessing
            XmlNode ppNode = doc.CreateElement(PROCESSING_STR);
            append_XmlNode_attribute(doc, ppNode, DELAY_STR, cinfo.intProcess_delay.ToString());

            node.AppendChild(ppNode);
            return node;
        }

        static public void ParseReponseXml(string xml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                bool havevalidmnode = false;
                foreach (XmlNode childnode in doc)
                {
                    if (childnode.NodeType == XmlNodeType.Element)
                    {
                        if (childnode.Attributes[PROTOCOL_VERSION_STR].Value != PROTOCOL_VERSION_VALUE)
                        {
                            throw new Exception("version is not correct, version=" + childnode.Attributes[PROTOCOL_VERSION_STR].Value);
                        }
                        if (childnode.Attributes[ID_STR].Value != PROTOCOL_RESPONSE_ID.ToString())
                        {
                            throw new Exception("response id is not correct, responseid=" + childnode.Attributes[ID_STR].Value);
                        }
                        if (childnode.InnerText != RESPONSE_SUCC_STR && childnode.InnerText != RESPONSE_GOT_STR)
                        {
                            throw new Exception("response is not correct,response content = " + childnode.InnerText + ", response xml = " + xml);
                        }
                        havevalidmnode = true;
                    }
                }
                if (!havevalidmnode)
                    throw new Exception(" not element node, response xml =" + xml);
            }
            catch (Exception e1)
            {
                throw new Exception("parser exception, error:" + e1.ToString() + "\r\n" + " xml: " + xml);
            }
        }

        static public void ParseScheduleXml(string xml, ref System.Collections.Hashtable CourseSchedule)
        {
            try
            {
                CourseSchedule.Clear();

                string schedulexml = GetSchedulePart(xml);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(schedulexml);

                foreach (XmlNode schedulenode in doc)
                {
                    if (schedulenode.NodeType == XmlNodeType.Element && schedulenode.Name == SCHEDULE_HEAD_TAG_STR)
                    {
                        if (schedulenode.Attributes[PROTOCOL_VERSION_STR].Value != PROTOCOL_VERSION_VALUE)
                        {
                            throw new Exception("version is not correct in " + QUERY_SCHEDULE_COMMAND_STR + " , version=" + schedulenode.Attributes[PROTOCOL_VERSION_STR].Value);
                        }

                        foreach (XmlNode node in schedulenode)
                        {
                            ParseScheduleXml(node, ref CourseSchedule);
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                throw new Exception("parse exception, error: " + e1.ToString() + "\r\n" + " xml: " + xml);
            }
        }

        static private string GetSchedulePart(string xml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                foreach (XmlNode schedulenode in doc)
                {
                    if (schedulenode.NodeType == XmlNodeType.Element && schedulenode.Name == SCHEDULE_HEAD_TAG_STR)
                    {
                        if (schedulenode.Attributes[PROTOCOL_VERSION_STR].Value != PROTOCOL_VERSION_VALUE)
                        {
                            throw new Exception("version is not correct in " + SCHEDULE_HEAD_TAG_STR + ", version=" + schedulenode.Attributes[PROTOCOL_VERSION_STR].Value);
                        }
                    }
                    foreach (XmlNode node1 in schedulenode)
                    {
                        if (node1.Name.ToLower() == "schedule")
                        {
                            foreach (XmlNode node2 in node1)
                            {
                                if (node2.NodeType == XmlNodeType.Text)
                                {
                                    return node2.Value;
                                }
                            }
                        }
                        throw new Exception("cannot found schedule section or text in it");
                    }
                }
            }
            catch (Exception e1)
            {
                throw new Exception("parse exception, error: " + e1.ToString() + "\r\n" + " xml: " + xml);
            }
            return string.Empty;
        }

        static private void ParseScheduleXml(XmlNode node, ref System.Collections.Hashtable CourseSchedule)
        {
            if (node.NodeType == XmlNodeType.Element && node.Name.ToLower() == "class")
            {
                CourseRecordInfo recordinfo = new CourseRecordInfo();
                recordinfo.datetimeStartTime = DateTime.ParseExact(node.Attributes[START_TIME_STR].Value, "MM dd yyyy HH mm ss", null);
                recordinfo.intStartTimer = Convert.ToInt32(node.Attributes[START_TIMER_STR].Value);
                recordinfo.intLength = Convert.ToInt32(node.Attributes[DURATION_STR].Value);

                CourseInfo courseinfo = new CourseInfo(0);

                foreach (XmlNode contentnode in node)
                {
                    if (contentnode.Name.ToLower() == COURSE_INFO_STR)
                    {
                        courseinfo.intCourseId = Convert.ToInt32(contentnode.Attributes[ID_STR].Value);
                        courseinfo.strCourseName = contentnode.Attributes[NAME_STR].Value;
                        courseinfo.intType = Convert.ToInt32(contentnode.Attributes[TYPE_STR].Value);
                    }
                    if (contentnode.Name.ToLower() == FTP_STR)
                    {
                        courseinfo.strFTPHost = contentnode.Attributes[SERVER_STR].Value;
                        courseinfo.strDataPath = contentnode.Attributes[DIRECTORY_STR].Value;
                    }
                    if (contentnode.Name.ToLower() == SCREENSHOT_STR)
                    {
                        courseinfo.intSCInterval = Convert.ToUInt32(contentnode.Attributes[INTERVAL_STR].Value);
                        courseinfo.intSCWidth = Convert.ToUInt32(contentnode.Attributes[WIDTH_STR].Value);
                        courseinfo.intSCHeight = Convert.ToUInt32(contentnode.Attributes[HEIGHT_STR].Value);
                        courseinfo.intSCHDivide = Convert.ToUInt32(contentnode.Attributes[H_DIVIDE_STR].Value);
                        courseinfo.intSCVDivide = Convert.ToUInt32(contentnode.Attributes[V_DIVIDE_STR].Value);
                        courseinfo.intSC_hcolorbits = Convert.ToUInt32(contentnode.Attributes[HI_COLORBITS_STR].Value);
                        courseinfo.intSC_lcolorbits = Convert.ToUInt32(contentnode.Attributes[LO_COLORBITS_STR].Value);
                    }
                    if (contentnode.Name.ToLower() == VIDEO_STR)
                    {
                        courseinfo.intChop_length = Convert.ToUInt32(contentnode.Attributes[CHOP_LEN_STR].Value);
                        courseinfo.intDenoise = Convert.ToUInt32(contentnode.Attributes[DENOISE_STR].Value);
                        foreach (XmlNode videonode in contentnode)
                        {
                            if (videonode.Name.ToLower() == HI_VIDEO_STR)
                            {
                                courseinfo.intHVideo_rate = Convert.ToUInt32(videonode.Attributes[RATE_STR].Value);
                                courseinfo.intHVideo_width = Convert.ToUInt32(videonode.Attributes[WIDTH_STR].Value);
                                courseinfo.intHVideo_height = Convert.ToUInt32(videonode.Attributes[HEIGHT_STR].Value);
                            }
                            if (videonode.Name.ToLower() == LO_VIDEO_STR)
                            {
                                courseinfo.intLVideo_rate = Convert.ToUInt32(videonode.Attributes[RATE_STR].Value);
                                courseinfo.intLVideo_width = Convert.ToUInt32(videonode.Attributes[WIDTH_STR].Value);
                                courseinfo.intLVideo_height = Convert.ToUInt32(videonode.Attributes[HEIGHT_STR].Value);
                                courseinfo.intlvideo_img_interval = Convert.ToUInt32(videonode.Attributes[IMAGE_INTERVCAL_STR].Value);
                            }
                        }
                    }
                    if (contentnode.Name.ToLower() == WHITEBOARD_STR)
                    {
                        courseinfo.intWB_interval = Convert.ToUInt32(contentnode.Attributes[INTERVAL_STR].Value);
                    }
                    if (contentnode.Name.ToLower() == PROCESSING_STR)
                    {
                        courseinfo.intProcess_delay = Convert.ToInt32(contentnode.Attributes[DELAY_STR].Value);
                    }
                }
                bool exist = false;
                foreach (CourseInfo cinfo in CourseSchedule.Keys)
                {
                    if (cinfo.intCourseId == courseinfo.intCourseId)
                    {
                        ((ArrayList)CourseSchedule[cinfo]).Add(recordinfo);
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    ArrayList recordlist = new ArrayList();
                    recordlist.Add(recordinfo);
                    CourseSchedule.Add(courseinfo, recordlist);
                }
            }
            else
            {
                foreach (XmlNode node1 in node)
                    ParseScheduleXml(node1, ref CourseSchedule);
            }
        }

        static private string updateengineconfiguration_command_xml(string commandname, int commandid, string IPCIP, string SvrPortalpage, string FTPUser, string FTPPassword, int classroomid, string screenshrinkdeptList, string screenshrinktoSizeInM)
        {
            XmlDocument doc = create_node_document();

            XmlNode commandNode = doc.CreateElement(commandname);

            append_XmlNode_VersionAndCommandID(doc, commandNode, commandid);

            doc.AppendChild(commandNode);
            //--ipc ip node
            XmlNode ipcNode = doc.CreateElement(INSTRUCTOR_PC_STR);
            append_XmlNode_attribute(doc, ipcNode, IP_STR, IPCIP);
            commandNode.AppendChild(ipcNode);

            //--svr portal page node
            XmlNode svrPageNode = doc.CreateElement(SERVER_STR);
            append_XmlNode_attribute(doc, svrPageNode, PORTAL_PAGE_STR, SvrPortalpage);
            commandNode.AppendChild(svrPageNode);

            //----ftp node
            XmlNode ftpNode = doc.CreateElement(FTP_STR);
            append_XmlNode_attribute(doc, ftpNode, USER_STR, FTPUser);
            append_XmlNode_attribute(doc, ftpNode, PASSWORD_STR, FTPPassword);
            commandNode.AppendChild(ftpNode);

            //-- uploading 
            XmlNode uploadNode = doc.CreateElement(UPLOADING_STR);
            append_XmlNode_attribute(doc, uploadNode, USER_STR, FTPUser);
            append_XmlNode_attribute(doc, uploadNode, PASSWORD_STR, FTPPassword);
            commandNode.AppendChild(uploadNode);

            //--classroomid in colengine
            XmlNode ppcNode = doc.CreateElement(PPC_STR);
            append_XmlNode_attribute(doc, ppcNode, CLASSROOMID_STR, classroomid.ToString());
            append_XmlNode_attribute(doc, ppcNode, ScreenShrinkDeptList_STR, screenshrinkdeptList);
            append_XmlNode_attribute(doc, ppcNode, ScreenShrinkToSizeInM_STR, screenshrinktoSizeInM);
            commandNode.AppendChild(ppcNode);

            return doc.OuterXml.ToString();
        }


        static private string updateagentconfiguration_command_xml(string commandname, int commandid, string PPCIP, string SvrPortalpage, int classroomid)
        {
            XmlDocument doc = create_node_document();

            XmlNode commandNode = doc.CreateElement(commandname);
            append_XmlNode_VersionAndCommandID(doc, commandNode, commandid);
            doc.AppendChild(commandNode);

            //--svr portal page node
            XmlNode svrPageNode = doc.CreateElement(SERVER_STR);
            append_XmlNode_attribute(doc, svrPageNode, PORTAL_PAGE_STR, SvrPortalpage);
            commandNode.AppendChild(svrPageNode);

            //--ppc ip node
            XmlNode ppcNode = doc.CreateElement(PPC_STR);
            append_XmlNode_attribute(doc, ppcNode, PPCIP_STR, PPCIP);
            commandNode.AppendChild(ppcNode);

            //--classroomid in colengine
            XmlNode ipcNode = doc.CreateElement(IPC_STR);
            append_XmlNode_attribute(doc, ipcNode, CLASSROOMID_STR, classroomid.ToString());
            commandNode.AppendChild(ipcNode);

            return doc.OuterXml.ToString();
        }

        static public string UploadLocalCoursesXml(ArrayList dirnames)
        {
            return simple_command_xml(UPLOAD_LOCALDATA_COMMAND_STR, UPLOAD_LOCALDATA_COMMAND_ID, dirnames);
        }

        static private string simple_command_xml(string commandname, int commandid, ArrayList dirnames)
        {
            XmlDocument doc = simple_command_xml_base(commandname, commandid);
            for (int i = 0; i < dirnames.Count; i++)
            {
                XmlNode nameNode = doc.CreateElement(DIRECTORY_STR);
                nameNode.InnerText = (string)dirnames[i];
                doc.DocumentElement.AppendChild(nameNode);
            }
            return doc.OuterXml;
        }
        static public string DeleteLocalCoursesXml(ArrayList dirnames)
        {
            return simple_command_xml(DEL_LOCALDATA_COMMAND_STR, DEL_LOCALDATA_COMMAND_ID, dirnames);
        }
    }
}