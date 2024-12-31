using System;
using System.Collections.Generic;
using System.IO;

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

        public BusinessResult<bool> AddContactBusiness(ContactTable contact)
        {
            int contactId = this.contactData.AddContactData(contact);

            string avatar = contact.Avatar.Replace("data:image/png;base64,", "");

            byte[] image = Convert.FromBase64String(avatar);

            string file = @$".\Avatar\{contactId}.png";

            if (File.Exists(file))
            {
                File.Delete(file);
            }

            File.WriteAllBytes(file, image);

            return new()
            {
                Success = true,
                Data = true
            };
        }

        public BusinessResult<bool> AddPhoneBusiness(PhoneTable phone, int userId)
        {
            this.contactData.AddPhoneData(phone, userId);

            return new()
            {
                Success = true,
                Data = true
            };
        }

        public BusinessResult<bool> AddFavoriteBusiness(FavoriteTable favorite, int userId)
        {
            this.contactData.AddFavoriteData(favorite, userId);

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

        public BusinessResult<bool> EditPhoneBusiness(PhoneTable phone, int userId)
        {
            this.contactData.EditPhoneData(phone, userId);

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

        public BusinessResult<ContactTable> GetContactBusiness(int contactId, int userId)
        {
            ContactTable contact = this.contactData.GetContactData(contactId, userId);

            string file = @$".\Avatar\{contactId}.png";

            contact.Avatar = "data:image/png;base64,";

            contact.Avatar += Convert.ToBase64String(File.ReadAllBytes(file));

            return new()
            {
                Success = true,
                Data = contact
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

        public BusinessResult<IEnumerable<PhoneTable>> GetPhonesBusiness(int contactId, int userId)
        {
            return new()
            {
                Success = true,
                Data = this.contactData.GetPhonesData(contactId, userId)
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

        public BusinessResult<bool> RemovePhoneBusiness(int phoneId, int userId)
        {
            this.contactData.RemovePhoneData(phoneId, userId);

            return new()
            {
                Success = true,
                Data = true
            };
        }

        public BusinessResult<bool> RemoveFavoriteBusiness(int contactId, int userId)
        {
            this.contactData.RemoveFavoritetData(contactId, userId);

            return new()
            {
                Success = true,
                Data = true
            };
        }
    }
}
