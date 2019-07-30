using MonitorAPI.Dao.framework;
using MonitorAPI.Model;
using System.Data.SqlClient;

namespace MonitorAPI.Dao
{
    class UserDao:BaseDao
    {
        private const string QUERY_BY_NameAndPwd_SQL = "SELECT * FROM [User] WHERE UserName=@Name and Password=@Password";

        public UserDao(PersistenceContext pc):base(pc) { }
        public bool UserExists(string Name,string Password) {
            using (SqlCommand command = new SqlCommand()) {
                command.Connection = Connection;
                command.CommandText = QUERY_BY_NameAndPwd_SQL;
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Password", Password);
                int result = (int)command.ExecuteScalar();
                return result ==1;
            }
        }

        public User GetUser(string Name, string Password)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = Connection;
                command.CommandText = QUERY_BY_NameAndPwd_SQL;
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Password", Password);
                User user = SqlHelper.ExecuteReaderCmdObject<User>(command);
                return user;
            }
        }
    }
}
