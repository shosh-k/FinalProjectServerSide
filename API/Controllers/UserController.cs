using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using BL;
using Models;

namespace API.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        BL.User u = new BL.User();

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("signup")]
        public int SignUp(UserModel users)
        {
            return u.SignUP(users);
        }
        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("signin/{phone}/{password}")]
        public int SignIn(string phone,string password)
        {
            return u.SignIn(phone, password);
        }

        [HttpGet]
        [Route("get")]
        [Route("GetAdress/{userId}")]

        public string GetAdress(int userId)
        { 
            return u.GetAdress(userId);
        }
    }
}
