﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Eleaning_Web.Model;
using Eleaning_Web.Services;
using Eleaning_Web.Interface;

namespace Eleaning_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceUser _user;
        public UserController(IServiceUser user)
        {
            _user = user;
        }
        [HttpGet("GetAllUser")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _user.GetAllUser();
            return Ok(users);
        }
        [HttpPost("Register")]
        public IActionResult Register(UserRequest request)
        {
            _user.Register(request);
            return Ok(new { message = "User created" });
        }
    }
}

