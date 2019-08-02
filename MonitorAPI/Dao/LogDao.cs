using MonitorAPI.Dao.framework;
using MonitorAPI.Model;
using System;
using System.Collections.Generic;
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
    }
}
