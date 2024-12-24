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
        private ContactBusiness business;

        public ContactController()
        {
            this.business = new ContactBusiness();
        }

        [HttpGet("phonetypes")]
        public BusinessResult<IEnumerable<PhoneTypeTable>> GetPhoneTypes()
        {
            return business.GetPhoneTypesBusiness();
        }
    }
}
