using Microsoft.Data.SqlClient;
using System.Collections.Generic;

using Contact.Model.Table;
using Contact.Utility;

namespace Contact.Data
{
    public class ContactData
    {
        private Crud crud;
        private SqlConnection db;

        public ContactData(SqlConnection db, Crud crud)
        {
            this.db = db;

            this.crud = crud;
        }

        public IEnumerable<PhoneTypeTable> GetPhoneTypesData()
        {
            return this.crud.Select<PhoneTypeTable>();
        }

        public void AddContactData(ContactTable contact)
        {
            this.crud.Insert(contact);
        }

        public IEnumerable<ContactTable> GetContactsData(int userId)
        {
            return this.crud.Select<ContactTable>();
        }

        public void RemoveContactData(int contactId, int userId)
        {
            this.crud.DeleteById<ContactTable>(contactId);
        }
    }
}
