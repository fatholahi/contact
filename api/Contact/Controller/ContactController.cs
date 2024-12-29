using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using Contact.Business;
using Contact.Model;
using Contact.Model.Table;

namespace Contact.Controller
{
    [ApiController]
    [Route("contact")]
    public class ContactController
    {
        private ContactBusiness contactBusiness;

        public ContactController(ContactBusiness contactBusiness)
        {
            this.contactBusiness = contactBusiness;
        }

        [HttpGet("phonetypes")]
        public BusinessResult<IEnumerable<PhoneTypeTable>> GetPhoneTypes()
        {
            return contactBusiness.GetPhoneTypesBusiness();
        }
    }
}
