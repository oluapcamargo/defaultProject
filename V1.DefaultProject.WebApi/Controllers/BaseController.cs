using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V1.DefaultProject.Application.ViewModels;

namespace V1.DefaultProject.WebApi.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        public int? UserId
        {
            get
            {
                var userClaim = User?.Claims.FirstOrDefault(x => x.Type == "sub");
                if (userClaim == null)
                {
                    return null;
                }

                if (int.TryParse(userClaim.Value, out int userId))
                {
                    return userId;
                }

                return null;
            }
        }

        public bool IsAdmin
        {
            get
            {
                var userClaim = User?.Claims.FirstOrDefault(x => x.Type == "user.admin");
                if (userClaim == null)
                {
                    return false;
                }

                return bool.TryParse(userClaim.Value, out var isAdmin) && isAdmin;
            }
        }

        public string UserEmail
        {
            get
            {
                var userClaim = User?.Claims?.FirstOrDefault(x => x.Type.ToLower() == "email");
                return userClaim?.Value;
            }
        }
        public string UserName
        {
            get
            {
                return User?.Identity?.Name;
            }
        }
    }
}
