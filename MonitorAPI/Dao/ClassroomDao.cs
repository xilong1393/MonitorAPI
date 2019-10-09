using MonitorAPI.Dao.framework;
using MonitorAPI.Model;
using MonitorAPI.Models;
using MonitorAPI.Models.OperationModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MonitorAPI.Dao
{
    public class ClassroomDao:BaseDao
    {
        public ClassroomDao(PersistenceContext pc) : base(pc) { }

        //private const string QUERY_CLASSROOMBYGROUPID_SQL = "SELECT * FROM CLASSROOM WHERE CLASSROOMGROUPID=@GROUPID";
        private const string QUERY_CLASSROOMBYID_SQL = "SELECT * FROM CLASSROOM WHERE ClassroomID=@ClassroomID";

        private const string QUERY_CLASSROOMBYGROUPID_SQL = "SELECT a.ClassroomID, a.ClassroomName, b.EngineStatus, c.AgentStatus, a.WBNUMBER, a.Status, b.PPCConnectionStatus, " +
            "b.AVStatus, b.FreeDisk FROM CLASSROOM a " +
            "left join ClassroomEngineStatus b on a.ClassroomID=b.ClassroomID " +
            "left join CLassroomAgentStatus c on b.ClassroomID=c.ClassroomID " +
            "WHERE CLASSROOMGROUPID=@GROUPID and classroomName like '%lauch' ORDER BY CLASSROOMNAME";

        private const string SQL_GETCLASSROOMSchedule_CLASSROOMGROUPID = "SELECT CLASSROOMID, CLASSROOMNAME, PSCLASSROOMNAME, CLASSROOM.CLASSROOMGROUPID, PPCPUBLICIP, IPCPUBLICIP, "+
            "SVRPORTALPAGEID, PPCPRIVATEIP, IPCPRIVATEIP, PPCPORT, IPCPORT, WBNUMBER,CLASSROOM.STATUS FROM CLASSROOM,ClassroomGroup "+
            "WHERE ClassroomGroup.CLASSROOMGROUPID=CLASSROOM.CLASSROOMGROUPID "+
            "and CLASSROOM.CLASSROOMGROUPID = @GROUPID ORDER BY CLASSROOM.CLASSROOMGROUPID,CLASSROOMNAME";

        private const string QUERY_CLASSROOMDetailBYID_SQL = "SELECT a.ClassroomID, a.ClassroomName, b.EngineStatus, c.AgentStatus, a.WBNUMBER, a.Status, b.PPCConnectionStatus, " +
          "b.AVStatus, b.FreeDisk FROM CLASSROOM a " +
          "left join ClassroomEngineStatus b on a.ClassroomID=b.ClassroomID " +
          "left join CLassroomAgentStatus c on b.ClassroomID=c.ClassroomID " +
          "WHERE a.CLASSROOMID=@CLASSROOMID";

        private const string QUERY_CLASSROOMINFODetailBYID_SQL = "SELECT a.ClassroomID, a.ClassroomName, a.PPCPublicIP, a.IPCPublicIP, b.EngineStatus, c.AgentStatus, a.WBNUMBER, a.Status, b.PPCConnectionStatus, " +
          "b.AVStatus, b.FreeDisk FROM CLASSROOM a " +
          "left join ClassroomEngineStatus b on a.ClassroomID=b.ClassroomID " +
          "left join CLassroomAgentStatus c on b.ClassroomID=c.ClassroomID " +
          "WHERE a.CLASSROOMID=@CLASSROOMID";

        internal ClassroomInfo GetClassroomInfoByID(int classID)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = Connection;
                command.CommandText = QUERY_CLASSROOMBYID_SQL;
                command.Parameters.AddWithValue("@ClassroomID", classID);
                ClassroomInfo classroomInfo = SqlHelper.ExecuteReaderCmdObject<ClassroomInfo>(command);
                return classroomInfo;
            }
        }

        public List<ClassroomView> GetClassroomByGroupID(int GroupID) {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = Connection;
                command.CommandText = QUERY_CLASSROOMBYGROUPID_SQL;
                command.Parameters.AddWithValue("@GROUPID", GroupID);
                List<ClassroomView> list = SqlHelper.ExecuteReaderCmdList<ClassroomView>(command);
                return list;
            }
        }

        public List<ClassroomScheduleView> GetClassroomScheduleByGroupID(int GroupID)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = Connection;
                command.CommandText = SQL_GETCLASSROOMSchedule_CLASSROOMGROUPID;
                command.Parameters.AddWithValue("@GROUPID", GroupID);
                List<ClassroomScheduleView> list = SqlHelper.ExecuteReaderCmdList<ClassroomScheduleView>(command);
                return list;
            }
        }

        public Classroom GetClassroomByID(int classroomID)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = Connection;
                command.CommandText = QUERY_CLASSROOMBYID_SQL;
                command.Parameters.AddWithValue("@ClassroomID", classroomID);
                Classroom classroom = SqlHelper.ExecuteReaderCmdObject<Classroom>(command);
                return classroom;
            }
        }

        public ClassroomInfoView GetClassroomDetailByID(int ClassroomID)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = Connection;
                command.CommandText = QUERY_CLASSROOMINFODetailBYID_SQL;
                command.Parameters.AddWithValue("@CLASSROOMID", ClassroomID);
                ClassroomInfoView classroomView = SqlHelper.ExecuteReaderCmdObject<ClassroomInfoView>(command);
                return classroomView;
            }
        }
    }
}
