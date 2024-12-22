using Contact.Data;
using Contact.Model;
using Contact.Model.Table;

namespace Contact.Business
{
    public class ContactBusiness
    {
        private ContactData data;

        public ContactBusiness()
        {
            this.data = new ContactData();
        }

        public BusinessResult<IEnumerable<PhoneTypeTable>> GetPhoneTypesBusiness()
        {
            BusinessResult<IEnumerable<PhoneTypeTable>> result = new();

            result.Success = true;
            result.Data = this.data.GetPhoneTypesData();

            return result;
        }
    }
}
