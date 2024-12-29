using Microsoft.Data.SqlClient;

using Dapper;

using Contact.Model.Table;
using Contact.Utility;

namespace Contact.Data
{
    public class UserData
    {
        private SqlConnection db;
        private Crud crud;

        public UserData(SqlConnection db, Crud crud)
        {
            this.db = db;

            this.crud = crud;
        }

        public int Insert(UserTable table)
        {
            return this.crud.Insert(table);
        }

        public int GetUserId(string username, byte[] password)
        {
            string sql = @"SELECT Id FROM [dbo].[User] WHERE Username = @Username AND Password = @Password";

            int id = db.ExecuteScalar<int>(sql, new { Username = username, Password = password });

            return id;
        }

        public UserTable GetUserInfoById(int id)
        {
            string sql = @"SELECT Username, FullName, Avatar FROM [dbo].[User] WHERE Id = @Id";

            UserTable table = db.QuerySingle<UserTable>(sql, new { Id = id });

            return table;
        }

        public void Test()
        {
            UserTable user = this.crud.GetById<UserTable>(2004);

            user.Fullname = "Reza";

            this.crud.UpdateById<UserTable>(user);
        }
    }
}
