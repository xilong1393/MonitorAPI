using MonitorAPI.Dao.framework;
using MonitorAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorAPI.Dao
{
    public class LogDao:BaseDao
    {
        private const string Insert_UserLogin_SQL = "INSERT INTO UserLoginLog values (@SessionID, @EmployeeID, @LoginTime, @LoginIP)";
        private const string Insert_UserOperation_SQL = "INSERT INTO UserOperationLog values (@SessionID, @Operation, @OperationTime)";
        public LogDao(PersistenceContext pc) : base(pc) { }
        public bool InsertUserLogin(UserLoginLog userLoginLog) {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = Connection;
                command.CommandText = Insert_UserLogin_SQL;
                command.Parameters.AddWithValue("@SessionID", userLoginLog.SessionID);
                command.Parameters.AddWithValue("@EmployeeID", userLoginLog.EmployeeID);
                command.Parameters.AddWithValue("@LoginTime", userLoginLog.LoginTime);
                command.Parameters.AddWithValue("@LoginIP", userLoginLog.LoginIP);
                int result = command.ExecuteNonQuery();
                return result == 1;
            }
        }
        public bool InsertUserOperation(UserOperationLog userOperationLog)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = Connection;
                command.CommandText = Insert_UserOperation_SQL;
                command.Parameters.AddWithValue("@SessionID", userOperationLog.SessionID);
                command.Parameters.AddWithValue("@Operation", userOperationLog.Operation);
                command.Parameters.AddWithValue("@OperationTime", userOperationLog.OperationTime);
                int result = command.ExecuteNonQuery();
                return result == 1;
            }
        }





        //from previous project
        private const string SQL_GETCOMMANDLOG = "SELECT LOGID, APPLICATION, IP, COMMAND, CLASSROOM, OPERATIONTIME, COMMANDSTATUS FROM RACOMMANDLOG WHERE LOGID > 0";
        private const string SQL_DELETECOMMANDLOG = "DELETE FROM RACOMMANDLOG";

        private const string SP_INSERTCOMMANDLOG = "INSERTCOMMANDLOG";


        public List<RACommandLog> GetCommandLog(DateTime dtStartTime, DateTime dtEndTime)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = Connection;
                command.CommandType = CommandType.Text;
                string sCondition = SQL_GETCOMMANDLOG;
                if (dtStartTime != DateTime.MinValue)
                {
                    sCondition += " AND OPERATIONTIME>=@STARTTIME";
                    command.Parameters.AddWithValue("@STARTTIME", dtStartTime);
                }
                if (dtEndTime != DateTime.MinValue)
                {
                    dtEndTime = dtEndTime.AddDays(1);
                    sCondition += " AND OPERATIONTIME<=@ENDTIME";
                    command.Parameters.AddWithValue("@ENDTIME", dtEndTime);
                }
                sCondition += " ORDER BY OPERATIONTIME DESC";
                command.CommandText = sCondition;
                List<RACommandLog> list = SqlHelper.ExecuteReaderCmdList<RACommandLog>(command);
                return list;
            }
        }

        public int InsertCommandLog(string sApplication, string sCommand, string sClassroom, string sIP, char cCommandStatus)
        {
            using (SqlCommand command = new SqlCommand()) {
                command.Connection = Connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SP_INSERTCOMMANDLOG;
                command.Parameters.AddWithValue("@APPLICATION", sApplication);
                command.Parameters.AddWithValue("@COMMAND", sCommand);
                command.Parameters.AddWithValue("@CLASSROOM", sClassroom);
                command.Parameters.AddWithValue("@IP", sIP);
                command.Parameters.AddWithValue("@OPERATIONTIME", DateTime.Now);
                command.Parameters.AddWithValue("@COMMANDSTATUS", cCommandStatus);
                return command.ExecuteNonQuery();
            }
        }

        public int ClearCommandLog() {
            using (SqlCommand command = new SqlCommand()) {
                command.Connection = Connection;
                command.CommandType = CommandType.Text;
                command.CommandText = SQL_DELETECOMMANDLOG;
                return command.ExecuteNonQuery();
            }
        }
    }
}
