using System.Collections.Generic;

using Contact.Data;
using Contact.Model;
using Contact.Model.Table;

namespace Contact.Business
{
    public class ContactBusiness
    {
        private ContactData contactData;

        public ContactBusiness(ContactData contactData)
        {
            this.contactData = contactData;
        }

        public BusinessResult<bool> AddContact(ContactTable request)
        {
            this.contactData.AddContactData(request);

            return new()
            {
                Success = true,
                Data = true
            };
        }

        public BusinessResult<bool> EditContactBusiness(ContactTable contact)
        {
            this.contactData.EditContactData(contact);

            return new()
            {
                Success = true,
                Data = true
            };
        }

        public BusinessResult<IEnumerable<PhoneTypeTable>> GetPhoneTypesBusiness()
        {
            return new()
            {
                Success = true,
                Data = this.contactData.GetPhoneTypesData()
            };
        }

        public BusinessResult<IEnumerable<ContactTable>> GetContactsBusiness(int userId)
        {
            return new()
            {
                Success = true,
                Data = this.contactData.GetContactsData(userId)
            };
        }

        public BusinessResult<bool> RemoveContactBusiness(int contactId, int userId)
        {
            this.contactData.RemoveContactData(contactId, userId);

            return new()
            {
                Success = true,
                Data = true
            };
        }
    }
}
