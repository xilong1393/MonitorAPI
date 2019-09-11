﻿using MonitorAPI.Dao;
using MonitorAPI.Dao.framework;
using MonitorAPI.Models;
using System;
using System.Collections;
using System.Data;

namespace MonitorAPI.Service.Operations
{
    public class SingleCommand
    {
        public static DataTable GetDataTableStyleLocalSchedule(int activeclassroomid)
        {
            CommandParameter parameter = QuerySchedule(activeclassroomid);
            Hashtable hstCourseRecording = new Hashtable();
            hstCourseRecording = (Hashtable)parameter.obj;
            DataTable displayedDataTables = FConvertToDatatable.ConvertScheduleToDataTable(hstCourseRecording);
            return displayedDataTables;
        }

        private static CommandParameter QuerySchedule(int activeclassroomid)
        {
            CommandParameter parameter = GetPPCParameter(activeclassroomid);
            if (!parameter.succ)
            {
                return parameter;
            }
            QuerySchedule proc = new QuerySchedule(parameter.ip, parameter.port);
            ExecuteCommand(proc, parameter);

            using (PersistenceContext pc = new PersistenceContext())
            {
                ClassroomDao classroomDao = new ClassroomDao(pc);
                Classroom classroom = classroomDao.GetClassroomByID(activeclassroomid);
                LogDao logDao = new LogDao(pc);
                logDao.InsertCommandLog("random_winform", "check schedule", classroom.ClassroomName, parameter.ip, parameter.succ ? 'S' : 'F');
                return parameter;
            }
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

        private static CommandParameter GetPPCParameter(int classroomid)
        {
            CommandParameter parameter = new CommandParameter();

            string ip = "";
            int port = 0;
            parameter.succ = GetIPPort(classroomid, ref parameter.ip, ref parameter.port, ref ip, ref port, ref parameter.error);
            return parameter;
        }

        private static bool GetIPPort(int classroomid, ref string PPCIP, ref int PPCPort, ref string IPCIP, ref int IPCPort, ref string error)
        {
            try
            {
                Classroom classroom = ServiceFactory.ClassroomService.GetClassroomByID(classroomid);
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
            catch (Exception e1)
            {
                error = e1.Message;
                return false;
            }
        }
    }
}