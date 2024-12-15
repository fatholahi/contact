using Contact.Model.Table;
using Dapper;
using Microsoft.Data.SqlClient;
using System.ComponentModel;

namespace Contact
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.;Database=Contacts;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";

            SqlConnection db = new SqlConnection(connectionString);

            db.Open();

            //string sql = "insert into dbo.[User] (Username, Password, FullName) values (@Username, @Password, @FullName)";

            //UserTable user = new UserTable()
            //{
            //    Username = "admin",
            //    Password = [],
            //    FullName = "Administrator"
            //};

            //object param = new
            //{
            //    Username = "mojtaba",
            //    Password = Array.Empty<byte>(),
            //    FullName = "Mojtaba"
            //};

            //db.Execute(sql, param);

            //string sql = "delete from dbo.[User] where Id <> @Id";

            //int affectedRows = db.Execute(sql, new { Id = 1001 });

            //Console.WriteLine(affectedRows);

            string sql = "select UserName, FullName, 1 Age from dbo.[User] WHERE 1 > 1";

            IEnumerable<UserTable> users = db.Query<UserTable>(sql);

            foreach (UserTable user in users)
            {
                Console.WriteLine($"UserId: {user.Id}, Username: {user.Username}, Full Name: {user.FullName}");
            }

            db.Close();
        }
    }
}
