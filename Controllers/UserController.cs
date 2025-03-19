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
    }
}