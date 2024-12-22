using Contact.Model;
using Contact.Model.Table;
using Contact.Utility;
using Microsoft.Data.SqlClient;

namespace Contact.Data
{
    public class ContactData
    {
        private Crud crud;
        private SqlConnection db;

        public ContactData()
        {
            string connectionString = "Server=.;Database=Contact;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";

            this.db = new(connectionString);

            this.crud = new(this.db);
        }

        public IEnumerable<PhoneTypeTable> GetPhoneTypesData()
        {
            return this.crud.Select<PhoneTypeTable>();
        }
    }
}
