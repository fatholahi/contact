using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

using Contact.Data;
using Contact.Model;
using Contact.Model.Table;
using Contact.Model.User;

namespace Contact.Business
{
	public class UserBusiness
	{
		public BusinessResult<int> RegisterBusiness(UserAddModel model)
		{
			BusinessResult<int> result = new();

			byte[] password = MD5.HashData(Encoding.UTF8.GetBytes(model.Password));

			model.ImageData = model.ImageData.Replace("data:image/png;base64,", "");

            byte[] avatar = Convert.FromBase64String(model.ImageData);

			if (!Directory.Exists(@".\Avatar"))
			{
				Directory.CreateDirectory(@".\Avatar");
			}

			string file = @$".\Avatar\{model.UserName.ToLower()}.png";

			if (File.Exists(file))
			{
				File.Delete(file);
			}

			File.WriteAllBytes(file, avatar);

			UserTable user = new()
			{
				Username = model.UserName,
				Password = password,
				FullName = model.FullName,
				Avatar = $"{model.UserName.ToLower()}.png"
			};

			result.Data = new UserData().Insert(user);

			result.Success = true;

			return result;
		}

		public BusinessResult<int> LoginBusiness(UserLoginModel model)
		{
			byte[] password = MD5.HashData(Encoding.UTF8.GetBytes(model.Password));

			int id = new UserData().GetUserId(model.Username, password);

			if (id == 0)
			{
				return new BusinessResult<int>()
				{
					Success = false,
					ErrorCode = 2002,
					ErrorMessage = "Invalid username or password"
				};
			}

			return new BusinessResult<int>()
			{
				Success = true,
				Data = id
			};
		}

		public BusinessResult<UserProfileModel> ProfileBusiness(int userId)
		{
			UserTable table = new UserData().GetUserInfoById(userId);

			string file = @$".\Avatar\{table.Username.ToLower()}.png";

			string data = "";

			if (File.Exists(file))
			{
				data = Convert.ToBase64String(File.ReadAllBytes(file));
			}

			return new BusinessResult<UserProfileModel>()
			{
				Success = true,
				Data = new UserProfileModel()
				{
					Avatar = data,
					UserName = table.Username,
					FullName = table.FullName,
				}
			};
		}
	}
}
