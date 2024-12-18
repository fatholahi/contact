using Contact.Model.Table;
using Contact.Utility;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Contact.Data
{
    public class UserData
    {
        private Crud crud;
        private SqlConnection db;

        public UserData()
        {
            string connectionString = "Server=.;Database=Contact;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";

            this.db = new(connectionString);

            this.crud = new(this.db);
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

            user.FullName = "Reza";

            this.crud.UpdateById<UserTable>(user);
        }
    }
}
