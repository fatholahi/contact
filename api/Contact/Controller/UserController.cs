using Microsoft.AspNetCore.Mvc;

using Contact.Business;
using Contact.Model;
using Contact.Model.User;

namespace Contact.Controller
{
    [ApiController]
    [Route("user")]
    public class UserController
    {
        private UserBusiness business;

        public UserController()
        {
            this.business = new UserBusiness();
        }

        [HttpPut("add")]
        public BusinessResult<int> Register(UserAddModel model)
        {
            return this.business.RegisterBusiness(model);
        }

        [HttpGet("profile")]
        public BusinessResult<UserProfileModel> Profile(int userId)
        {
            return this.business.ProfileBusiness(userId);
        }
    }
}
