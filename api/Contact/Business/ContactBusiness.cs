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

        public BusinessResult<IEnumerable<PhoneTypeTable>> GetPhoneTypesBusiness()
        {
            BusinessResult<IEnumerable<PhoneTypeTable>> result = new();
            
            result.Success = true;

            result.Data = this.contactData.GetPhoneTypesData();

            return result;
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
