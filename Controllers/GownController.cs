using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Pos.Services;
using RentalSystem.Models;
using RentalSystem.Services;

namespace RentalSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GownController : Controller
    {
        GownServices srvcs;
        IHubContext<Hub> _hub;

        public GownController(GownServices srvcs, IHubContext<Hub> hubContext)
        {
            this.srvcs = srvcs;
            _hub = hubContext;
        }

        [HttpGet]
        public async Task<List<Gowns>> Gowns()
        {
            var ret = await srvcs.Gowns();
            return ret;
        }

        [HttpGet]
        public async Task<List<Gowns>> SearchGown(string search)
        {
            var ret = await srvcs.SearchGown(search);
            return ret;
        }

        [HttpGet]
        public async Task<List<Gowns>> AvailableGowns()
        {
            var ret = await srvcs.AvailableGowns();
            return ret;
        }

        [HttpPost]
        public async Task<int> AddGown([FromBody] Gowns gown)
        {
            var ret = await srvcs.AddGown(gown);
            return ret;
        }

        [HttpPut]
        public async Task<int> UpdateGown([FromBody] Gowns gown)
        {
            var ret = await srvcs.UpdateGown(gown);
            return ret;
        }
    }
}
