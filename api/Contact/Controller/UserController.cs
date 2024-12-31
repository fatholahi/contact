using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Contact.Business;
using Contact.Model;
using Contact.Model.User;
using Contact.Utility;

namespace Contact.Controller
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private UserBusiness userBusiness;

        public UserController(UserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        [HttpPost("login")]
        public BusinessResult<string> Login(UserLoginModel model)
        {
            BusinessResult<int> result = this.userBusiness.LoginBusiness(model);

            if (result.Success)
            {
                int userId = result.Data;

                string token = Token.Generate(userId);

                return new()
                {
                    Success = true,
                    Data = token
                };
            }
            else
            {
                return new()
                {
                    Success = false,
                    ErrorCode = result.ErrorCode,
                    ErrorMessage = result.ErrorMessage
                };
            }
        }

        [HttpPost("register")]
        public BusinessResult<int> Register(UserAddModel model)
        {
            return this.userBusiness.RegisterBusiness(model);
        }

        [Authorize]
        [HttpGet("profile")]
        public BusinessResult<UserProfileModel> Profile()
        {
            int userId = int.Parse(base.User.Identity.Name);

            return this.userBusiness.ProfileBusiness(userId);
        }
    }
}
