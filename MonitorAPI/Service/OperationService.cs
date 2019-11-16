using MonitorAPI.Dao;
using MonitorAPI.Dao.framework;
using MonitorAPI.Models;
using MonitorAPI.Models.OperationModel;
using MonitorAPI.Service.FUNC;
using MonitorAPI.Service.Operations;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MonitorAPI.Service
{
    public class OperationService
    {
        //push schedule
        public CommandParameter PushSchedule(int classroomID, string sessionID = "Winform_Random_User")
        {
            CommandParameter parameter = GetPPCParameter(classroomID);
            if (!parameter.succ)
            {
                return parameter;
            }

            using (PersistenceContext pc = new PersistenceContext())
            {
                OperationDao operationDao = new OperationDao(pc);
                List<ClassRecordingWithSchedule> list = operationDao.GetClassroomRecordingByClassroomID(classroomID);
                DataTable dtschedule = CreateDataTable(list);
                parameter.obj = dtschedule;
                PushSchedule proc = new PushSchedule(parameter.ip, parameter.port, dtschedule);
                ExecuteCommand(proc, parameter);

                ClassroomDao classroomDao = new ClassroomDao(pc);
                Classroom classroom = classroomDao.GetClassroomByID(classroomID);
                LogDao logDao = new LogDao(pc);
                logDao.InsertCommandLog(sessionID, "push schedule", classroom.ClassroomName, parameter.ip, parameter.succ ? 'S' : 'F');
                return parameter;
            }
        }

        internal DatePeriod GetDatePeriod(int nDays)
        {
            using (PersistenceContext pc = new PersistenceContext())
            {
                OperationDao operationDao = new OperationDao(pc);
                DatePeriod datePeriod = operationDao.GetDatePeriod(nDays);
                return datePeriod;
            }
        }

        private void ExecuteCommand(PushSchedule proc, CommandParameter parameter)
        {
            try
            {
                parameter.obj = proc.Execute();
                parameter.succ = true;
            }
            catch (Exception e1)
            {
                parameter.succ = false;
                parameter.error = e1.Message;
            }
        }

        private CommandParameter GetPPCParameter(int classroomID)
        {
            CommandParameter parameter = new CommandParameter();

            string ip = "";
            int port = 0;
            parameter.succ = GetIPPort(classroomID, ref parameter.ip, ref parameter.port, ref ip, ref port, ref parameter.error);
            return parameter;
        }

        private bool GetIPPort(int classroomID, ref string PPCIP, ref int PPCPort, ref string IPCIP, ref int IPCPort, ref string error)
        {
            try
            {
                using (PersistenceContext pc = new PersistenceContext())
                {
                    Classroom classroom = new ClassroomDao(pc).GetClassroomByID(classroomID);
                    if (classroom == null)
                    {
                        error = "no classroom";
                        return false;
                    }
                    PPCIP = classroom.PPCPublicIP;
                    PPCPort = classroom.PPCPort;
                    IPCIP = classroom.IPCPublicIP;
                    IPCPort = classroom.IPCPort;
                    return true;
                }
            }
            catch (Exception e1)
            {
                error = e1.Message;
                return false;
            }
        }
        protected static DataTable CreateDataTable<T>(IEnumerable<T> enumerable)
        {
            System.Reflection.PropertyInfo[] pis = typeof(T).GetProperties();

            //create data table
            DataTable table = new DataTable();
            foreach (System.Reflection.PropertyInfo pi in pis)
            {
                if (pi.PropertyType == typeof(System.Nullable<Boolean>))
                {
                    table.Columns.Add(pi.Name, typeof(Boolean));
                }
                else if (pi.PropertyType == typeof(System.Nullable<Int16>))
                {
                    table.Columns.Add(pi.Name, typeof(Int16));
                }
                else if (pi.PropertyType == typeof(System.Nullable<Int32>))
                {
                    table.Columns.Add(pi.Name, typeof(Int32));
                }
                else if (pi.PropertyType == typeof(System.Nullable<Int64>))
                {
                    table.Columns.Add(pi.Name, typeof(Int64));
                }
                else if (pi.PropertyType == typeof(System.Nullable<Char>))
                {
                    table.Columns.Add(pi.Name, typeof(Char));
                }
                else if (pi.PropertyType == typeof(System.Nullable<DateTime>))
                {
                    table.Columns.Add(pi.Name, typeof(DateTime));
                }
                else
                {
                    table.Columns.Add(pi.Name, pi.PropertyType);
                }
            }

            //add rows to DataTable
            foreach (T elem in enumerable)
            {
                DataRow row = table.NewRow();

                foreach (System.Reflection.PropertyInfo pi in pis)
                {
                    if (pi.GetValue(elem, null) == null)
                    {
                        row[pi.Name] = DBNull.Value;
                    }
                    else
                    {
                        row[pi.Name] = pi.GetValue(elem, null);
                    }
                }
                table.Rows.Add(row);
            }
            return table;
        }
        static private void ExecuteCommand(SingleCommandProcessor processor, CommandParameter parameter)
        {
            try
            {
                parameter.obj = processor.Execute();
                parameter.succ = true;
            }
            catch (Exception e1)
            {
                parameter.succ = false;
                parameter.error = e1.Message;
            }
        }

        //stop record
        public CommandParameter StopRecord(int classroomID, string sessionID = "")
        {
            CommandParameter parameter = GetPPCParameter(classroomID);
            if (!parameter.succ)
            {
                return parameter;
            }

            using (PersistenceContext pc = new PersistenceContext(System.Transactions.IsolationLevel.ReadCommitted))
            {
                OperationDao operationDao = new OperationDao(pc);
                int result = operationDao.UpdateClassRecording(classroomID, 'S');
                StopRecord proc = new StopRecord(parameter.ip, parameter.port);
                ExecuteCommand(proc, parameter);


                ClassroomDao classroomDao = new ClassroomDao(pc);
                Classroom classroom = classroomDao.GetClassroomByID(classroomID);
                LogDao logDao = new LogDao(pc);
                logDao.InsertCommandLog(sessionID, "stop record", classroom.ClassroomName, parameter.ip, parameter.succ ? 'S' : 'F');
                return parameter;
            }
        }

        //abort record
        public CommandParameter AbortRecord(int classroomID, string sessionID = "")
        {
            CommandParameter parameter = GetPPCParameter(classroomID);
            if (!parameter.succ)
            {
                return parameter;
            }

            using (PersistenceContext pc = new PersistenceContext(System.Transactions.IsolationLevel.ReadCommitted))
            {
                OperationDao operationDao = new OperationDao(pc);
                int result = operationDao.UpdateClassRecording(classroomID, 'D');
                AbortRecord proc = new AbortRecord(parameter.ip, parameter.port);
                ExecuteCommand(proc, parameter);

                ClassroomDao classroomDao = new ClassroomDao(pc);
                Classroom classroom = classroomDao.GetClassroomByID(classroomID);
                LogDao logDao = new LogDao(pc);
                logDao.InsertCommandLog(sessionID, "abort record", classroom.ClassroomName, parameter.ip, parameter.succ ? 'S' : 'F');
                return parameter;
            }
        }

        //update ppc configuration
        public CommandParameter UpdatePPCConfig(int classroomID, string sessionID = "")
        {
            UpdateEngineConfigurationParameter engineConfig = new UpdateEngineConfigurationParameter();
            UpdateAgentConfigurationParamerer agentConfig = new UpdateAgentConfigurationParamerer();
            CommandParameter parameter = new CommandParameter();

            if (!GetUpdateParameter(classroomID, ref engineConfig, ref agentConfig))
            {
                parameter.succ = false;
                parameter.error = "get engine or agent param";
                return parameter;
            }

            // update Engine
            CommandParameter engineParam = GetPPCParameter(classroomID);
            if (!engineParam.succ)
            {
                return engineParam;
            }
            using (PersistenceContext pc = new PersistenceContext())
            {
                OperationDao operationDao = new OperationDao(pc);
                int result = operationDao.UpdateClassRecording(classroomID, 'D');
                UpdateEngineConfiguration engineProc = new UpdateEngineConfiguration(engineParam.ip, engineParam.port,
                                                    FWebConfig.ScreenShrinkDeptList, FWebConfig.ScreenShrinkToSizeInM, engineConfig);
                ExecuteCommand(engineProc, engineParam);

                ClassroomDao classroomDao = new ClassroomDao(pc);
                Classroom classroom = classroomDao.GetClassroomByID(classroomID);
                LogDao logDao = new LogDao(pc);
                logDao.InsertCommandLog(sessionID, "update configuration - engine", classroom.ClassroomName, engineParam.ip, engineParam.succ ? 'S' : 'F');
                if (!engineParam.succ)
                {
                    return engineParam;
                }

                CommandParameter agentParam = GetIPCParameter(classroomID);
                if (!agentParam.succ)
                {
                    return agentParam;
                }
                UpdateAgentConfiguration agentproc = new UpdateAgentConfiguration(agentParam.ip, agentParam.port, agentConfig);
                ExecuteCommand(agentproc, agentParam);
                logDao.InsertCommandLog(sessionID, "update configuration - agent", classroom.ClassroomName, agentParam.ip, agentParam.succ ? 'S' : 'F');
                if (!agentParam.succ)
                {
                    return agentParam;
                }
                return parameter;
            }
        }

        public CommandParameter GetImageString(int classroomID, string sessionID = "")
        {
            UpdateEngineConfigurationParameter engineConfig = new UpdateEngineConfigurationParameter();
            UpdateAgentConfigurationParamerer agentConfig = new UpdateAgentConfigurationParamerer();
            CommandParameter parameter = new CommandParameter();

            if (!GetUpdateParameter(classroomID, ref engineConfig, ref agentConfig))
            {
                parameter.succ = false;
                parameter.error = "get engine or agent param";
                return parameter;
            }

            // update Engine
            CommandParameter engineParam = GetPPCParameter(classroomID);
            if (!engineParam.succ)
            {
                return engineParam;
            }
            using (PersistenceContext pc = new PersistenceContext())
            {
                OperationDao operationDao = new OperationDao(pc);
                int result = operationDao.UpdateClassRecording(classroomID, 'D');

                GetImageString getImageString = new GetImageString(engineParam.ip, engineParam.port,
                                                    FWebConfig.ScreenShrinkDeptList, FWebConfig.ScreenShrinkToSizeInM, engineConfig);
                ExecuteCommand(getImageString, engineParam);

                if (engineParam.succ)
                {
                    return engineParam;
                }
                else
                {
                    parameter.succ = false;
                    parameter.error = "get binary image string failed";
                    return parameter;
                }
            }
        }

        public CommandParameter GetAudioData(int classroomID, string sessionID = "")
        {
            UpdateEngineConfigurationParameter engineConfig = new UpdateEngineConfigurationParameter();
            UpdateAgentConfigurationParamerer agentConfig = new UpdateAgentConfigurationParamerer();
            CommandParameter parameter = new CommandParameter();

            if (!GetUpdateParameter(classroomID, ref engineConfig, ref agentConfig))
            {
                parameter.succ = false;
                parameter.error = "get engine or agent param";
                return parameter;
            }

            // update Engine
            CommandParameter engineParam = GetPPCParameter(classroomID);
            if (!engineParam.succ)
            {
                return engineParam;
            }
            using (PersistenceContext pc = new PersistenceContext())
            {
                OperationDao operationDao = new OperationDao(pc);
                int result = operationDao.UpdateClassRecording(classroomID, 'D');

                GetAudioData getAudioData = new GetAudioData(engineParam.ip, engineParam.port,
                                                    FWebConfig.ScreenShrinkDeptList, FWebConfig.ScreenShrinkToSizeInM, engineConfig);
                ExecuteCommand(getAudioData, engineParam);

                if (engineParam.succ)
                {
                    return engineParam;
                }
                else
                {
                    parameter.succ = false;
                    parameter.error = "get binary audio data failed";
                    return parameter;
                }
            }
        }

        private bool GetUpdateParameter(int classroomID, ref UpdateEngineConfigurationParameter enginepar, ref UpdateAgentConfigurationParamerer agentpar)
        {
            try
            {
                using (PersistenceContext pc = new PersistenceContext())
                {
                    ClassroomDao classroomDao = new ClassroomDao(pc);
                    Classroom classroom = classroomDao.GetClassroomByID(classroomID);
                    if (classroom == null)
                    {
                        return false;
                    }
                    string SvrPortalpage = FUNC.FWebConfig.PortalPage;

                    enginepar.classroomid = classroomID;
                    enginepar.FTPUser = FUNC.FWebConfig.FileServerUsername;
                    enginepar.FTPPassword = FUNC.FWebConfig.FileServerPassword;
                    enginepar.IPCIP = classroom.IPCPrivateIP;
                    enginepar.SvrPortalpage = SvrPortalpage;

                    agentpar.classroomid = classroomID;
                    agentpar.PPCIP = classroom.PPCPrivateIP;
                    agentpar.SvrPortalpage = SvrPortalpage;
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        //RebootPPC
        public CommandParameter RebootPPC(int classroomID, string sessionID = "")
        {
            CommandParameter parameter = GetPPCParameter(classroomID);
            if (!parameter.succ)
            {
                return parameter;
            }

            using (PersistenceContext pc = new PersistenceContext())
            {
                OperationDao operationDao = new OperationDao(pc);
                RebootPC proc = new RebootPC(parameter.ip, parameter.port);
                ExecuteCommand(proc, parameter);

                ClassroomDao classroomDao = new ClassroomDao(pc);
                Classroom classroom = classroomDao.GetClassroomByID(classroomID);
                LogDao logDao = new LogDao(pc);
                logDao.InsertCommandLog(sessionID, "Reboot PPC", classroom.ClassroomName, parameter.ip, parameter.succ ? 'S' : 'F');
                return parameter;
            }
        }

        //RebootIPC
        public CommandParameter RebootIPC(int classroomID, string sessionID = "")
        {
            CommandParameter parameter = GetIPCParameter(classroomID);
            if (!parameter.succ)
            {
                return parameter;
            }

            using (PersistenceContext pc = new PersistenceContext())
            {
                OperationDao operationDao = new OperationDao(pc);
                RebootPC proc = new RebootPC(parameter.ip, parameter.port);
                ExecuteCommand(proc, parameter);

                ClassroomDao classroomDao = new ClassroomDao(pc);
                Classroom classroom = classroomDao.GetClassroomByID(classroomID);
                LogDao logDao = new LogDao(pc);
                logDao.InsertCommandLog(sessionID, "Reboot IPC", classroom.ClassroomName, parameter.ip, parameter.succ ? 'S' : 'F');
                return parameter;
            }
        }

        //Check Schedule
        public CommandParameter CheckSchedule(int classroomID, string sessionID = "")
        {
            CommandParameter parameter = GetPPCParameter(classroomID);
            if (!parameter.succ)
            {
                return parameter;
            }
            DataTable dt = FCompareSchedule.CompareClassSchedule(classroomID);
            parameter.obj = JsonConvert.SerializeObject(dt);
            return parameter;
        }

        //List local record
        public CommandParameter ListLocalData(int classroomID, string sessionID = "")
        {
            CommandParameter parameter = GetPPCParameter(classroomID);
            if (!parameter.succ)
            {
                return parameter;
            }

            using (PersistenceContext pc = new PersistenceContext())
            {
                ListLocalData proc = new ListLocalData(parameter.ip, parameter.port);
                ExecuteCommand(proc, parameter);

                ClassroomDao classroomDao = new ClassroomDao(pc);
                Classroom classroom = classroomDao.GetClassroomByID(classroomID);
                LogDao logDao = new LogDao(pc);
                logDao.InsertCommandLog(sessionID, "list local record", classroom.ClassroomName, parameter.ip, parameter.succ ? 'S' : 'F');
                return parameter;
            }
        }

        //upload local course
        public CommandParameter UploadLocalCourse(int classroomID, ArrayList dirnames, string sessionID = "")
        {
            CommandParameter parameter = GetPPCParameter(classroomID);
            if (!parameter.succ)
            {
                return parameter;
            }

            using (PersistenceContext pc = new PersistenceContext())
            {
                UploadLocalCourses proc = new UploadLocalCourses(parameter.ip, parameter.port, dirnames);
                ExecuteCommand(proc, parameter);

                ClassroomDao classroomDao = new ClassroomDao(pc);
                Classroom classroom = classroomDao.GetClassroomByID(classroomID);
                LogDao logDao = new LogDao(pc);
                logDao.InsertCommandLog(sessionID, "upload local record", classroom.ClassroomName, parameter.ip, parameter.succ ? 'S' : 'F');
                return parameter;
            }
        }
        //upload local course
        public CommandParameter DeleteLocalCourse(int classroomID, ArrayList dirnames, string sessionID = "")
        {
            CommandParameter parameter = GetPPCParameter(classroomID);
            if (!parameter.succ)
            {
                return parameter;
            }

            using (PersistenceContext pc = new PersistenceContext())
            {
                DeleteLocalCourses proc = new DeleteLocalCourses(parameter.ip, parameter.port, dirnames);
                ExecuteCommand(proc, parameter);

                ClassroomDao classroomDao = new ClassroomDao(pc);
                Classroom classroom = classroomDao.GetClassroomByID(classroomID);
                LogDao logDao = new LogDao(pc);
                logDao.InsertCommandLog(sessionID, "delete local record", classroom.ClassroomName, parameter.ip, parameter.succ ? 'S' : 'F');
                return parameter;
            }
        }

        private CommandParameter GetIPCParameter(int classroomID)
        {
            CommandParameter parameter = new CommandParameter();

            string ip = "";
            int port = 0;

            parameter.succ = GetIPPort(classroomID, ref ip, ref port, ref parameter.ip, ref parameter.port, ref parameter.error);
            return parameter;
        }

        private List<ClassRecordingWithSchedule> GetClassRecordingbyClassroomID(int nClassroomID)
        {
            using (PersistenceContext pc = new PersistenceContext())
            {
                OperationDao operationDao = new OperationDao(pc);
                List<ClassRecordingWithSchedule> list = operationDao.GetClassRecordingByClassroomID(nClassroomID);
                return list;
            }
        }

        public DataTable GetClassRecordingTablebyClassroomID(int nClassroomID)
        {
            List<ClassRecordingWithSchedule> list = GetClassRecordingbyClassroomID(nClassroomID);
            return CreateDataTable<ClassRecordingWithSchedule>(list);
        }
        public bool InsertClassSchedule(ClassSchedule newSchedule) {
            using (PersistenceContext pc = new PersistenceContext())
            {
                OperationDao operationDao = new OperationDao(pc);
                int res = operationDao.InsertClassSchedule(newSchedule);
                return res >= 1;
            }
        }
    }
}