using MonitorAPI.Dao.framework;
using MonitorAPI.Models;
using MonitorAPI.Models.OperationModel;
using MonitorAPI.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MonitorAPI.Dao
{
    public class OperationDao:BaseDao
    {
        public OperationDao(PersistenceContext pc) : base(pc) { }

        private const string SQL_QUERY_GETCLASSRECORDING_BYCLASSROOMID = "SELECT  CLASSROOMNAME,CLASSRECORDINGID, CLASSRECORDING.CLASSSTARTTIME, CLASSRECORDING.STATUS, UPLOADED, UPLOADTIME, FILESERVERNAME, CLASSRECORDING.CLASSDATADIR, ENGINEVERSION, WHITEBOARDNUM,CLASSRECORDING.CLASSID, VIEWABLE, CLASSRECORDING.CLASSSCHEDULEID, FlashDataPath, FlashStatus, PodCastDataPath, PodCastStatus, CLASSNAME, ISPERIODICCOURSE, CLASSLENGTH, FILESERVERID, CLASSTYPEID, CLASSROOM.CLASSROOMID, INSTRUCTORNAME, QUARTERID, ISPOSTDELAY, ISPODCAST, UPLOADDURATION, UPLOADXML, RecordingName, RecordingDescription FROM CLASSRECORDING,CLASSSCHEDULE,CLASSROOM WHERE CLASSSCHEDULE.CLASSROOMID=CLASSROOM.CLASSROOMID AND CLASSRECORDING.CLASSSCHEDULEID=CLASSSCHEDULE.CLASSSCHEDULEID AND CLASSSCHEDULE.CLASSROOMID=@CLASSROOMID AND DATEADD(ss,CLASSLENGTH,CLASSRECORDING.CLASSSTARTTIME) > GETDATE() AND CLASSRECORDING.STATUS='E' ORDER BY CLASSRECORDING.CLASSSTARTTIME ASC";
        private const string SQL_QUERY_GETCLASSRECORDING_BYCLASSROOMID1 = "SELECT  CLASSROOMNAME,CLASSRECORDINGID, CLASSRECORDING.CLASSSTARTTIME, CLASSRECORDING.STATUS, UPLOADED, UPLOADTIME, FILESERVERNAME, CLASSRECORDING.CLASSDATADIR, ENGINEVERSION, WHITEBOARDNUM,CLASSRECORDING.CLASSID, VIEWABLE, CLASSRECORDING.CLASSSCHEDULEID, FlashDataPath, FlashStatus, PodCastDataPath, PodCastStatus, CLASSNAME, ISPERIODICCOURSE, CLASSLENGTH, FILESERVERID, CLASSTYPEID, CLASSROOM.CLASSROOMID, INSTRUCTORNAME, QUARTERID, ISPOSTDELAY, ISPODCAST, UPLOADDURATION, UPLOADXML, RecordingName, RecordingDescription FROM CLASSRECORDING,CLASSSCHEDULE,CLASSROOM WHERE CLASSSCHEDULE.CLASSROOMID=CLASSROOM.CLASSROOMID AND CLASSRECORDING.CLASSSCHEDULEID=CLASSSCHEDULE.CLASSSCHEDULEID AND CLASSSCHEDULE.CLASSROOMID=@CLASSROOMID AND DATEADD(ss,CLASSLENGTH,CLASSRECORDING.CLASSSTARTTIME) > "+ "'2012-07-18 21:32:48.430'"+" AND CLASSRECORDING.STATUS='E' ORDER BY CLASSRECORDING.CLASSSTARTTIME ASC";

        

        private const string SP_UPDATE_CLASSRECORDINGSTATUS = "UPDATECLASSRECORDINGSTATUS";
        private const string SP_UPDATE_CLASSRECORDINGCSTATUS = "UPDATECLASSRECORDINGCSTATUS";

        private const string SQL_GETCLASSRECORDING_CLASSROOMID= "SELECT  CLASSROOMNAME,CLASSRECORDINGID, CLASSRECORDING.CLASSSTARTTIME, CLASSRECORDING.STATUS, UPLOADED, UPLOADTIME, FILESERVERNAME, CLASSRECORDING.CLASSDATADIR, ENGINEVERSION, WHITEBOARDNUM,CLASSRECORDING.CLASSID, VIEWABLE, CLASSRECORDING.CLASSSCHEDULEID, FlashDataPath, FlashStatus, PodCastDataPath, PodCastStatus, CLASSNAME, ISPERIODICCOURSE, CLASSLENGTH, FILESERVERID, CLASSTYPEID, CLASSROOM.CLASSROOMID, INSTRUCTORNAME, QUARTERID, ISPOSTDELAY, ISPODCAST, UPLOADDURATION, UPLOADXML, RecordingName, RecordingDescription FROM CLASSRECORDING,CLASSSCHEDULE,CLASSROOM WHERE CLASSSCHEDULE.CLASSROOMID=CLASSROOM.CLASSROOMID AND CLASSRECORDING.CLASSSCHEDULEID=CLASSSCHEDULE.CLASSSCHEDULEID AND CLASSSCHEDULE.CLASSROOMID=@CLASSROOMID";
        private const string SQL_GETDATEPERIOD = "SELECT GETDATE() AS STARTDATE,DATEADD(D, @DAYS, GETDATE()) AS ENDDATE";

        private const string SP_INSERTCLASSSCHEDULE = "INSERTCLASSSCHEDULE";

        public List<ClassRecordingWithSchedule> GetClassroomRecordingByClassroomID(int classroomID)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = Connection;
                command.CommandText = SQL_QUERY_GETCLASSRECORDING_BYCLASSROOMID;
                command.Parameters.AddWithValue("@CLASSROOMID", classroomID);
                List<ClassRecordingWithSchedule> list = SqlHelper.ExecuteReaderCmdList<ClassRecordingWithSchedule>(command);
                return list;
            }
        }

        //public int UpdateClassRecording(int nClassID, DateTime dtClassStartTime, char cUploaded, string sClassDataDir, int nWBNum, int nUploadDuration, string sUploadXML)
        //{
        //    using (SqlCommand command = new SqlCommand())
        //    {
        //        command.Connection = Connection;
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = SP_UPDATE_CLASSRECORDINGSTATUS;
        //        command.Parameters.AddWithValue("@CLASSID", nClassID);
        //        command.Parameters.AddWithValue("@UPLOADED", cUploaded);
        //        command.Parameters.AddWithValue("@CLASSSTARTTIME", dtClassStartTime);
        //        command.Parameters.AddWithValue("@CLASSDATADIR", sClassDataDir);
        //        command.Parameters.AddWithValue("@WBNUM", nWBNum);
        //        command.Parameters.AddWithValue("@UPLOADDURATION", nUploadDuration);
        //        command.Parameters.AddWithValue("@UPLOADXML", sUploadXML);
        //        int result = command.ExecuteNonQuery();
        //        return result;
        //    }
        //}

        public int UpdateClassRecording(int nClassroomID, char cStatus)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = Connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP_UPDATE_CLASSRECORDINGCSTATUS;
                command.Parameters.AddWithValue("@CLASSROOMID", nClassroomID);
                command.Parameters.AddWithValue("@STATUS", cStatus);
                int result = command.ExecuteNonQuery();
                return result;
            }
        }

        public List<ClassRecordingWithSchedule> GetClassRecordingByClassroomID(int nClassroomID) {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = Connection;
                command.CommandType = CommandType.Text;
                command.CommandText = SQL_GETCLASSRECORDING_CLASSROOMID;
                command.Parameters.AddWithValue("@CLASSROOMID", nClassroomID);
                List<ClassRecordingWithSchedule> result = SqlHelper.ExecuteReaderCmdList<ClassRecordingWithSchedule>(command);
                return result;
            }
        }
        public DatePeriod GetDatePeriod(int nDays)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = Connection;
                command.CommandType = CommandType.Text;
                command.CommandText = SQL_GETDATEPERIOD;
                command.Parameters.AddWithValue("@DAYS", nDays);
                DatePeriod result = SqlHelper.ExecuteReaderCmdObject<DatePeriod>(command);
                return result;
            }
        }

        public int InsertClassSchedule(ClassSchedule newSchedule) {
            // /\:?"<>|*
            newSchedule.ClassName = newSchedule.ClassName.Replace('/', '-');
            newSchedule.ClassName = newSchedule.ClassName.Replace('\\', '-');
            newSchedule.ClassName = newSchedule.ClassName.Replace(':', '-');
            newSchedule.ClassName = newSchedule.ClassName.Replace('?', '-');
            newSchedule.ClassName = newSchedule.ClassName.Replace('"', '-');
            newSchedule.ClassName = newSchedule.ClassName.Replace('<', '-');
            newSchedule.ClassName = newSchedule.ClassName.Replace('>', '-');
            newSchedule.ClassName = newSchedule.ClassName.Replace('|', '-');
            newSchedule.ClassName = newSchedule.ClassName.Replace('*', '-');
            bool bBracket = newSchedule.ClassName.Contains("[") && newSchedule.ClassName.Contains("]");
            if (bBracket == true)
            {
                int nStart = newSchedule.ClassName.IndexOf('[');
                int nEnd = newSchedule.ClassName.IndexOf(']');
                string sDir = newSchedule.ClassName.Substring(nStart + 1, nEnd - nStart - 1);
                newSchedule.ClassDataDir = sDir.Replace(" ", "");
            }
            else
            {
                newSchedule.ClassDataDir = newSchedule.ClassName;
            }
            if (newSchedule.ClassID == 0 || newSchedule.ClassTypeID != 1)
            {
                newSchedule.ClassID = -1;
            }
            if (!newSchedule.IsPeriodicCourse)
            {
                newSchedule.WeekDayID = (int)newSchedule.ClassStartTime.DayOfWeek + 1;
                newSchedule.ClassStartDate = newSchedule.ClassStartTime;
                newSchedule.ClassEndDate = newSchedule.ClassStartTime;
            }
            newSchedule.ClassDataDir = FormatDataDir(newSchedule.ClassTypeID, newSchedule.ClassDataDir);

            using (SqlCommand command = new SqlCommand()) {
                command.Connection = Connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP_INSERTCLASSSCHEDULE;
                FillParams(command, newSchedule);

                return command.ExecuteNonQuery();
            }

        }

        protected void FillParams(SqlCommand SQL, Object obj)
        {
            PropertyInfo[] pis = obj.GetType().GetProperties();

            foreach (PropertyInfo pi in pis)
            {
                SqlDbType type = SqlDbType.VarChar;
                if (pi.PropertyType == typeof(Char) || pi.PropertyType == typeof(Nullable<Char>))
                {
                    type = SqlDbType.Char;
                }
                else if (pi.PropertyType == typeof(Boolean) || pi.PropertyType == typeof(Nullable<Boolean>))
                {
                    type = SqlDbType.Bit;
                }
                else if (pi.PropertyType == typeof(DateTime) || pi.PropertyType == typeof(Nullable<DateTime>))
                {
                    type = SqlDbType.DateTime;
                }
                else if (pi.PropertyType == typeof(Int16) || pi.PropertyType == typeof(Nullable<Int16>))
                {
                    type = SqlDbType.SmallInt;
                }
                else if (pi.PropertyType == typeof(Int32) || pi.PropertyType == typeof(Nullable<Int32>))
                {
                    type = SqlDbType.Int;
                }
                else if (pi.PropertyType == typeof(Int64) || pi.PropertyType == typeof(Nullable<Int64>))
                {
                    type = SqlDbType.BigInt;
                }
                AddParamToSQLCmd(SQL, "@" + pi.Name, type, 0, ParameterDirection.Input, pi.GetValue(obj, null));
            }
        }
        protected void AddParamToSQLCmd(SqlCommand SQL, string paramID, SqlDbType sqlType, int paramSize,
            ParameterDirection paramDirection, object paramvalue)
        {

            if (SQL == null)
                throw (new Exception("Invalid SqlCommand."));
            if (paramID == string.Empty)
                throw (new Exception("Invalid ParamID."));

            SqlParameter newSqlParam = new SqlParameter();
            newSqlParam.ParameterName = paramID;
            newSqlParam.SqlDbType = sqlType;
            newSqlParam.Direction = paramDirection;

            if (paramSize > 0)
                newSqlParam.Size = paramSize;

            newSqlParam.Value = (paramvalue != null ? paramvalue : System.DBNull.Value);

            SQL.Parameters.Add(newSqlParam);
        }

        private String FormatDataDir(int classTypeID, String DataDir)
        {
            if (String.IsNullOrEmpty(DataDir) == false)
            {
                DataDir = DataDir.Replace(' ', '-');
                switch (classTypeID)
                {
                    case 3:
                        DataDir = @"TestCourse/" + DataDir;
                        break;
                    case 4:
                    case 5:
                        DataDir = @"SeminarCourse/" + DataDir;
                        break;
                    default:
                        break;
                }
            }
            return DataDir;
        }
    }
}