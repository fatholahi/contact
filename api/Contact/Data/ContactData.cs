using System.Collections.Generic;

using Contact.Model.Table;
using Contact.Utility;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Contact.Data
{
    public class ContactData
    {
        private SqlConnection db;
        private Crud crud;

        public ContactData(SqlConnection db, Crud crud)
        {
            this.db = db;
            this.crud = crud;
        }

        public void AddContactData(ContactTable contact)
        {
            this.crud.Insert(contact);
        }

        public void AddPhoneData(PhoneTable phone, int userId)
        {
            this.crud.Insert(phone);
        }

        public void AddFavoriteData(FavoriteTable favorite, int userId)
        {
            this.crud.Insert(favorite);
        }

        public void EditContactData(ContactTable contact)
        {
            this.crud.UpdateById(contact);
        }

        public void EditPhoneData(PhoneTable phone, int userId)
        {
            this.crud.UpdateById(phone);
        }

        public IEnumerable<ContactTable> GetContactsData(int userId)
        {
            return this.crud.Select<ContactTable>();
        }

        public IEnumerable<PhoneTypeTable> GetPhoneTypesData()
        {
            return this.crud.Select<PhoneTypeTable>();
        }

        public void RemoveContactData(int contactId, int userId)
        {
            this.crud.DeleteById<ContactTable>(contactId);
        }

        public void RemovePhoneData(int phoneId, int userId)
        {
            this.crud.DeleteById<PhoneTable>(phoneId);
        }

        public void RemoveFavoritetData(int contactId, int userId)
        {
            this.db.Execute("DELETE FROM dbo.Favorite WHERE ContactId = @ContactId", new { ContactId = contactId });
        }
    }
}
