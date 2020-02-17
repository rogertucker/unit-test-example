using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLayer.Services;

namespace ViewLayer.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _logger = logger;
            _userService = userService;
        }
        [Route("api/user")]
        [HttpPost]
        public IActionResult Create(User user)
        {
            user = _userService.AddUser(user);
            return (Created("api/user/" + user.ID, user));
        }

        [Route("api/user/{userId}")]
        [HttpGet]
        public IActionResult GetById(int userId)
        {
            User user = _userService.GetById(userId);
            return Ok(user);
        }

        [Route("api/user/lastname/{lastName}")]
        [HttpGet]
        public IActionResult GetByLastName(string lastName)
        {
            User user = _userService.GetUserByLastName(lastName);
            return Ok(user);
        }
    }
}
