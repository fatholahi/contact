﻿using System;
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
		private UserData userData;

		public UserBusiness(UserData userData)
		{
			this.userData = userData;
		}

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

			string file = @$".\Avatar\{model.Username.ToLower()}.png";

			if (File.Exists(file))
			{
				File.Delete(file);
			}

			File.WriteAllBytes(file, avatar);

			UserTable user = new()
			{
				Username = model.Username,
				Password = password,
				Fullname = model.Fullname,
				Avatar = $"{model.Username.ToLower()}.png"
			};

			result.Data = this.userData.Insert(user);

			result.Success = true;

			return result;
		}

		public BusinessResult<int> LoginBusiness(UserLoginModel model)
		{
			byte[] password = MD5.HashData(Encoding.UTF8.GetBytes(model.Password));

			int id = this.userData.GetUserId(model.Username, password);

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
			UserTable table = this.userData.GetUserInfoById(userId);

			string file = @$".\Avatar\{table.Username.ToLower()}.png";

			string data = "data:image/png;base64,";

			if (File.Exists(file))
			{
				data += Convert.ToBase64String(File.ReadAllBytes(file));
			}

			return new BusinessResult<UserProfileModel>()
			{
				Success = true,
				Data = new UserProfileModel()
				{
					Avatar = data,
					Username = table.Username,
					Fullname = table.Fullname,
				}
			};
		}
	}
}
