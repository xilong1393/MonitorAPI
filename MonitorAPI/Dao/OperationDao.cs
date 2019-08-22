using MonitorAPI.Dao.framework;
using MonitorAPI.Models;
using MonitorAPI.Models.OperationModel;
using MonitorAPI.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MonitorAPI.Dao
{
    public class OperationDao:BaseDao
    {
        public OperationDao(PersistenceContext pc) : base(pc) { }

        private const string SQL_QUERY_GETCLASSRECORDING_BYCLASSROOMID = "SELECT  CLASSROOMNAME,CLASSRECORDINGID, CLASSRECORDING.CLASSSTARTTIME, CLASSRECORDING.STATUS, UPLOADED, UPLOADTIME, FILESERVERNAME, CLASSRECORDING.CLASSDATADIR, ENGINEVERSION, WHITEBOARDNUM,CLASSRECORDING.CLASSID, VIEWABLE, CLASSRECORDING.CLASSSCHEDULEID, FlashDataPath, FlashStatus, PodCastDataPath, PodCastStatus, CLASSNAME, ISPERIODICCOURSE, CLASSLENGTH, FILESERVERID, CLASSTYPEID, CLASSROOM.CLASSROOMID, INSTRUCTORNAME, QUARTERID, ISPOSTDELAY, ISPODCAST, UPLOADDURATION, UPLOADXML, RecordingName, RecordingDescription FROM CLASSRECORDING,CLASSSCHEDULE,CLASSROOM WHERE CLASSSCHEDULE.CLASSROOMID=CLASSROOM.CLASSROOMID AND CLASSRECORDING.CLASSSCHEDULEID=CLASSSCHEDULE.CLASSSCHEDULEID AND CLASSSCHEDULE.CLASSROOMID=@CLASSROOMID AND DATEADD(ss,CLASSLENGTH,CLASSRECORDING.CLASSSTARTTIME) > GETDATE() AND CLASSRECORDING.STATUS='E' ORDER BY CLASSRECORDING.CLASSSTARTTIME ASC";
        private const string SP_UPDATE_CLASSRECORDINGSTATUS = "UPDATECLASSRECORDINGSTATUS";
        private const string SP_UPDATE_CLASSRECORDINGCSTATUS = "UPDATECLASSRECORDINGCSTATUS";
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
    }
}