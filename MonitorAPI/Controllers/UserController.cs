using MonitorAPI.Model;
using MonitorAPI.Models;
using MonitorAPI.Service;
using MonitorAPI.Util;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MonitorAPI.Controllers
{
    public class UserController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public IHttpActionResult GetUserLogin(UserLoginForm userLoginForm) {
            try
            {
                UserService service = ServiceFactory.UserService;
                User user = service.UserLogin(userLoginForm.UserName, userLoginForm.Password);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
    }
}