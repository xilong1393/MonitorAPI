using MonitorAPI.Dao.framework;
using MonitorAPI.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MonitorAPI.Dao
{
    public class ClassroomDao:BaseDao
    {
        //private const string QUERY_CLASSROOMBYGROUPID_SQL = "SELECT * FROM CLASSROOM WHERE CLASSROOMGROUPID=@GROUPID";
        private const string QUERY_CLASSROOMBYID_SQL = "SELECT * FROM CLASSROOM WHERE ClassroomID=@ClassroomID";

        private const string QUERY_CLASSROOMBYGROUPID_SQL = "SELECT a.ClassroomID, a.ClassroomName, b.EngineStatus, c.AgentStatus, a.WBNUMBER, a.Status, b.PPCConnectionStatus, " +
            "b.AVStatus, b.FreeDisk FROM CLASSROOM a " +
            "left join ClassroomEngineStatus b on a.ClassroomID=b.ClassroomID " +
            "left join CLassroomAgentStatus c on b.ClassroomID=c.ClassroomID " +
            "WHERE CLASSROOMGROUPID=@GROUPID";

        internal ClassroomInfo GetClassroomID(int classID)
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

        public ClassroomDao(PersistenceContext pc) : base(pc) { }
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
    }
}
