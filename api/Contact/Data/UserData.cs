using Contact.Model.Table;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Contact.Data
{
    public class UserData
    {
        public int Insert(UserTable table)
        {
            string connectionString = "Server=.;Database=Contact;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";

            SqlConnection db = new(connectionString);

            db.Open();

            string sql = @"INSERT INTO [dbo].[User]
(Username, Password, FullName, Avatar)
OUTPUT INSERTED.Id
VALUES (@Username, @Password, @FullName, @Avatar)";

            int id = db.ExecuteScalar<int>(sql, table);

            db.Close();

            return id;
        }

        public int GetUserId(string username, byte[] password)
        {
            string connectionString = "Server=.;Database=Contact;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";

            SqlConnection db = new(connectionString);

            db.Open();

            string sql = @"SELECT Id FROM [dbo].[User] WHERE Username = @Username AND Password = @Password";

            int id = db.ExecuteScalar<int>(sql, new { Username = username, Password = password });

            db.Close();

            return id;
        }

        public UserTable GetUserInfoById(int id)
        {
            string connectionString = "Server=.;Database=Contact;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";

            SqlConnection db = new(connectionString);

            db.Open();

            string sql = @"SELECT Username, FullName, Avatar FROM [dbo].[User] WHERE Id = @Id";

            UserTable table = db.QuerySingle<UserTable>(sql, new { Id = id });

            db.Close();

            return table;
        }
    }
}
