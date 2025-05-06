using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pos.Services;
using RentalSystem.Models;

namespace RentalSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        UserServices srvcs;

        public UserController(UserServices srvcs)
        {
            this.srvcs = srvcs;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<Users>> UserLogin(string username, string password)
        {
            var ret = await srvcs.UserLogin(username, password);
            return ret;
        }

        [HttpGet]
        public async Task<List<Users>> Users()
        {
            var ret = await srvcs.Users();
            return ret;
        }

        [HttpGet]
        public async Task<List<Users>> SearchUsers(string search)
        {
            var ret = await srvcs.SearchUsers(search);
            return ret;
        }

        [HttpPost]
        public async Task<int> Register([FromBody] Users user)
        {
            var ret = await srvcs.Register(user);
            return ret;
        }

    }
}