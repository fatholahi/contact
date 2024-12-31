using System.Collections.Generic;

using Contact.Model.Table;
using Contact.Utility;

namespace Contact.Data
{
    public class ContactData
    {
        private Crud crud;

        public ContactData(Crud crud)
        {
            this.crud = crud;
        }

        public void AddContactData(ContactTable contact)
        {
            this.crud.Insert(contact);
        }

        public void EditContactData(ContactTable contact)
        {
            this.crud.UpdateById(contact);
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
    }
}
