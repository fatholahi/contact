using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using Contact.Business;
using Contact.Model;
using Contact.Model.Table;

namespace Contact.Controller
{
    [ApiController, Authorize]
    [Route("contact")]
    public class ContactController : ControllerBase
    {
        private ContactBusiness contactBusiness;

        public ContactController(ContactBusiness contactBusiness)
        {
            this.contactBusiness = contactBusiness;
        }

        [HttpPost("addcontact")]
        public BusinessResult<bool> AddContact(ContactTable request)
        {
            int userId = int.Parse(base.User.Identity.Name);

            request.UserId = userId;

            return contactBusiness.AddContactBusiness(request);
        }

        [HttpPost("addphone")]
        public BusinessResult<bool> AddPhone(PhoneTable request)
        {
            int userId = int.Parse(base.User.Identity.Name);

            return contactBusiness.AddPhoneBusiness(request, userId);
        }

        [HttpPost("addfavorite")]
        public BusinessResult<bool> AddFavorite(FavoriteTable request)
        {
            int userId = int.Parse(base.User.Identity.Name);

            return contactBusiness.AddFavoriteBusiness(request, userId);
        }

        [HttpPut("editcontact")]
        public BusinessResult<bool> EditContact(ContactTable request)
        {
            int userId = int.Parse(base.User.Identity.Name);

            request.UserId = userId;

            return contactBusiness.EditContactBusiness(request);
        }

        [HttpPut("editphone")]
        public BusinessResult<bool> EditPhone(PhoneTable request)
        {
            int userId = int.Parse(base.User.Identity.Name);

            return contactBusiness.EditPhoneBusiness(request,  userId);
        }

        [HttpGet("getcontact")]
        public BusinessResult<ContactTable> GetContacts(int request)
        {
            int userId = int.Parse(base.User.Identity.Name);

            return contactBusiness.GetContactBusiness(request, userId);
        }

        [HttpGet("getcontacts")]
        public BusinessResult<IEnumerable<ContactTable>> GetContacts()
        {
            int userId = int.Parse(base.User.Identity.Name);

            return contactBusiness.GetContactsBusiness(userId);
        }

        [HttpGet("phonetypes")]
        public BusinessResult<IEnumerable<PhoneTypeTable>> GetPhoneTypes()
        {
            return contactBusiness.GetPhoneTypesBusiness();
        }

        [HttpDelete("removecontact")]
        public BusinessResult<bool> RemoveContact(int request)
        {
            int userId = int.Parse(base.User.Identity.Name);

            return contactBusiness.RemoveContactBusiness(request, userId);
        }

        [HttpDelete("removephone")]
        public BusinessResult<bool> RemovePhone(int request)
        {
            int userId = int.Parse(base.User.Identity.Name);

            return contactBusiness.RemovePhoneBusiness(request, userId);
        }

        [HttpDelete("removefavorite")]
        public BusinessResult<bool> RemoveFavorite(int request)
        {
            int userId = int.Parse(base.User.Identity.Name);

            return contactBusiness.RemoveFavoriteBusiness(request, userId);
        }
    }
}
