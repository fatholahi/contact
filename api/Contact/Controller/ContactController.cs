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


        [HttpPut("addcontact")]
        public BusinessResult<bool> AddContact(ContactTable request)
        {
            int userId = int.Parse(base.User.Identity.Name);

            request.UserId = userId;

            return contactBusiness.AddContact(request);
        }

        [HttpPut("editcontact")]
        public BusinessResult<bool> EditContact(ContactTable request)
        {
            int userId = int.Parse(base.User.Identity.Name);

            request.UserId = userId;

            return contactBusiness.EditContactBusiness(request);
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
    }
}
